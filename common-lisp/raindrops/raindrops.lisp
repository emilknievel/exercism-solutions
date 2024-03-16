(defpackage :raindrops
  (:use :cl)
  (:export :convert))

(in-package :raindrops)

(defun convert (n)
  "Converts a number to a string of raindrop sounds."
  (let ((s ""))
    (when (zerop (mod n 3))
      (setf s (concatenate 'string s "Pling")))
    (when (zerop (mod n 5))
      (setf s (concatenate 'string s "Plang")))
    (when (zerop (mod n 7))
      (setf s (concatenate 'string s "Plong")))
    (if (string= s "") (write-to-string n :base 10)
        s)))
