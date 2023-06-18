(defpackage :lillys-lasagna
  (:use :cl)
  (:export :expected-time-in-oven
           :remaining-minutes-in-oven
           :preparation-time-in-minutes
           :elapsed-time-in-minutes))

(in-package :lillys-lasagna)

(defun expected-time-in-oven ()
  "How many minutes the lasagna should be in the oven"
  337)

(defun remaining-minutes-in-oven (minutes-spent)
  "How many minutes the lasagna still has to remain in the oven"
  (- (expected-time-in-oven) minutes-spent))

(defun preparation-time-in-minutes (layers)
  "How many minutes that have been spent preparing the lasagna"
  (* 19 layers))
  
(defun elapsed-time-in-minutes (layers time-in-oven)
  "How many minutes have been spent cooking the lasagna"
  (+ (preparation-time-in-minutes layers) time-in-oven))
