(ns interest-is-interesting)

(defn interest-rate
  [balance]
  (condp > balance
    0    -3.213
    1000 0.5
    5000 1.621
    2.475))

(defn annual-balance-update
  [balance]
  (+ balance
     (* balance
        (/ (bigdec (Math/abs (interest-rate balance)))
           100M))))

(defn donate-big-amount
  [balance tax-free-percentage]
  (int (* balance (/ (* tax-free-percentage 2) 100))))

(defn amount-to-donate
  [balance tax-free-percentage]
  (if (pos? balance)
    (donate-big-amount balance tax-free-percentage)
    0))
