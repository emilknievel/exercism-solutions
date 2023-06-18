(defpackage :gigasecond-anniversary
  (:use :cl)
  (:export :from))
(in-package :gigasecond-anniversary)

(defun from-universal (year month day hour minute second)
  (+ (encode-universal-time second minute hour day month year 0) (expt 10 9)))

(defun from (year month day hour minute second)
  (multiple-value-bind
        (sec min hr dy mth yr)
      (decode-universal-time (from-universal year month day hour minute second))
    (list yr mth dy hr min sec)))
