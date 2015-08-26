#lang racket
(define (trace s v) (printf s v))

(define strict-fns (list (list '+ +) (list '- -) (list '* *)
                         (list 'null? null?) (list '> >) (list '< <) (list '= =) (list 'trace trace)
                         (list 'car (lambda (x) (force (car x))))
                         (list 'cdr (lambda (x) (force (cdr x))))))

(define lazy-fns (list
                   (list 'cons cons)
                   (list 'if (lambda (test e1 e2) (if (force test)
                                                    (force e1)
                                                    (force e2))))))

(define trace-evaluate #t)

(define (match x exps env)
  (if (null? exps)
    (error 'match "No pattern to match to")
    (let ((m (matcher x (caar exps) env)))
      (if (eq? m 'fail)
        (match x (cdr exps) env)
        (evaluate-env (cadar exps) m)))))

(define (matcher x exp env)
  (cond ((number? exp)
         (if (eq? x exp)
           env
           'fail))
        ((string? exp)
         (if (eq? x exp)
           env
           'fail))
        ((symbol? exp)
         (add-var-env exp x env))
        ((pair? exp)
         (cond ((eq? (car exp) 'cons)
                (if (pair? x)
                  (let ((e1 (matcher (car x) (cadr exp) env)))
                    (if (eq? 'fail e1)
                      'fail
                      (matcher (cdr x) (caddr exp) e1)))
                  'fail))
               ((eq? (car exp) 'quote)
                (if (equal? (cadr exp) x)
                  env
                  'fail))
               (else 'fail)))
        (else 'fail)))

;; Thunk stuff
(define (eq-car? l v) (and (pair? l) (eq? (car l) v)))

; Change the value of a thunk (used in evaluate to set the value of a possibly recursive definition
(define (update-thunk thunk lam code)
  (set-box! thunk (list 'unevaluated lam code)))

; Create an empty thunk - use this in add-defs to create empty values for the variables.  The var is for error messages.
(define (empty-thunk var)
  (box (list 'undefined var)))

; Create a thunk.  The prog is the code associated with the thunk - just for error messages
(define (thunk lam code) (box (list 'unevaluated lam code)))

; Create a thunk from a constant
(define (thunk-constant v) (box (list 'evaluated v)))

; Get the value of a thunk - comment out the prints if needed.
; Use a 'working state to detect infinite loops.
(define (force thunk)
  (write-string (format "Forcing ~A\n" thunk))
  (let ((c (unbox thunk)))
    (cond ((eq-car? c 'working) (error 'force "Infinite Loop in ~A\n" (cadr c)))
          ((eq-car? c 'undefined) (error 'force "Evaluating ~A before it is defined\n" (cadr c)))
          ((eq-car? c 'unevaluated)
           (set-box! thunk (list 'working (caddr c)))
           (write-string (format "Forcing ~A\n" (caddr c)))
           (let ((v ((cadr c))))
             (set-box! thunk (list 'evaluated v))
             (write-string (format "Value of ~A is ~A\n" (caddr c) v))
             v))
          ((eq-car? c 'evaluated)
           (cadr c))
          (else
            (error 'force "Bad thunk: ~A\n" c)))))

; This removes thunks from a list so it can be printed.  Use this to print the outputs in evaluate.
(define (purify x)
  (cond ((pair? x)
         (cons (purify (force (car x))) (purify (force (cdr x)))))
        (else x)))

(define (thunk-list x)
  (if (pair? x)
    (cons (thunk-list (car x)) (thunk-list (cdr x)))
    (thunk-constant x)))

(define prims (append (map (lambda (f) (list (car f) (thunk-constant (list 'strict (cadr f))))) strict-fns)
                      (map (lambda (f) (list (car f) (thunk-constant (list 'lazy (cadr f))))) lazy-fns)))

;;Macro stuff
(define (expand-cond clauses)
  (cond ((null? clauses)
         (error 'expand-cond "Bad input in cond"))
        ((eq? (caar clauses) 'else)
         (cadar clauses))
        (else
          (list 'if (caar clauses) (cadar clauses) (expand-cond (cdr clauses))))))

(define (expand-let clauses)
  (cons (list 'lambda (map (lambda (arg) (car arg)) (car clauses)) (cadr clauses)) (map (lambda (arg) (cadr arg)) (car clauses))))

(define (get-macro name env)
  (cond ((null? env)
         #f)
        ((eq? name (caar env))
         (cadar env))
        (else
          (get-macro name (cdr env)))))

(define meta-env (list (list 'cond expand-cond) (list 'let expand-let)))

;;Environment manipulation
;; get-env , returns the value of var in env.
(define (get-env var env)
  (cond ((null? env)
         ((error 'get-env "Variable ~A not found" var)))
        ((eq? var (caar env))
         (if (eq? 'undefined (cadar env))
           (error 'get-env "Variable ~A referenced before assignment" var)
           (cadar env)))
        (else
          (get-env var (cdr env)))))

;; Adds variable var with value val to env
(define (add-var-env var val env)
  (cons (list var val) env))

;; Adds vars with values to env
(define (add-vars-env vars vals env)
  (if (or (null? vars) (null? vals))
    env
    (cons (list (car vars) (car vals)) (add-vars-env (cdr vars) (cdr vals) env))))

;;Changes values in env
(define (set-env var val env)
  (cond ((null? env)
         (error 'set-env "Variable ~A does not exist" var))
        ((eq? var (caar env))
         (set-box! (cadar env) val))
        (else
          (set-env var val (cdr env)))))

;;Evaluator stuff

;; Return an environment of all defines in env, all set to undefined for recursion
(define (get-defs exp)
  (cond ((null? exp)
         '())
        ((and (pair? (car exp)) (eq? (caar exp) 'define))
         (cons (list (cadar exp) (empty-thunk (cadar exp))) (get-defs (cdr exp))))
        (else
          (get-defs (cdr exp)))))

;; Evaluate exp after adding defines to the primitive env
(define (evaluate exps)
  (let ((top-env (append (get-defs exps) prims)))
    (map (lambda (exp) ; Map the following to all of the expressions
           (cond ((and (pair? exp) (eq? (car exp) 'define)) ; If its a define
                  (printf "~A has been defined \n" (cadr exp))
                  (update-thunk (get-env (cadr exp) top-env) (lambda () (evaluate-env (caddr exp) top-env))(caddr exp)))
                 (else
                   ;(printf "~A\n" top-env)
                   (printf "The value of ~A = ~A\n" exp (purify (evaluate-env exp top-env)))))) exps)))

;; Evaluate the exp in env
(define (evaluate-env exp env)
  (if trace-evaluate (printf "Evaluating ~A\n" exp) '())
  (let ((res (cond ((pair? exp)
                    (evaluate-list (car exp) (cdr exp) env))
                   ((symbol? exp)
                    (force (get-env exp env)))
                   ((number? exp)
                    exp)
                   ((string? exp)
                    exp)
                   (else
                     (error 'evaluate-env "Something not possible")))))
    (if trace-evaluate (printf "Value of ~A is ~A\n" exp res) '())
    res))

(define (evaluate-list fn args env)
  (cond ((eq? fn 'quote)
         (car args))
        ((eq? fn 'match)
         (match (evaluate-env (car args) env) (cadr args) env))
        ((eq? fn 'lambda)
         (list 'closure (car args) (cadr args) env))
        ((get-macro fn meta-env)
         (evaluate-env ((get-macro fn meta-env) args) env))
        (else
          (evaluate-call fn args env))))

(define (evaluate-call fn args env)
  (let ((ef (evaluate-env fn env))
        (earg (map (lambda (arg) (thunk (lambda () (evaluate-env arg env)) arg)) args)))
    (cond ((and (pair? ef) (eq? 'closure (car ef)))
           (evaluate-env (caddr ef) (add-vars-env (cadr ef) earg (cadddr ef))))
          ((eq-car? ef 'strict)
           (apply (cadr ef) (map force earg)))
          ((eq-car? ef 'lazy)
           (apply (cadr ef) earg))
          ((procedure? ef)
           (printf "eval call:  ~A ~A\n" ef earg)
           (apply ef earg))
          (else
            (error 'evaluate-call "Something screwy - Bad function: ~A" ef)))))

(evaluate '((define iterate (lambda (f v) (cons v (iterate f (f v))))) (car (cdr (iterate (lambda (x) (+ x 1)) 0)))))
;(evaluate '((define repeat (lambda (x) (cons x (repeat x)))) (car (repeat 2))))
;(evaluate '((define x (+ x 1)) x))
