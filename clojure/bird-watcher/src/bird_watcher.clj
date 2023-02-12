(ns bird-watcher)

(def last-week 
  [0 2 5 3 7 8 4])

(defn today [birds]
  (peek birds))

(defn inc-bird [birds]
  (conj (pop birds) (inc (today birds))))

(defn day-without-birds? [birds]
  (true? (some zero? birds)))

(defn n-days-count [birds n]
  (reduce + (take n birds)))

(defn busy-day? [birds-seen]
  (> birds-seen 4))

(defn busy-days [birds]
  (count (filter busy-day? birds)))

(defn odd-week? [birds]
  (= [1 0 1 0 1 0 1] birds))
