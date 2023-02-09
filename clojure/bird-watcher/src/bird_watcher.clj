(ns bird-watcher)

(def last-week 
  [0 2 5 3 7 8 4])

(defn today [birds]
  (last birds))

(defn inc-bird [birds]
  (conj (drop-last birds) (inc (today birds))))

(defn day-without-birds? [birds]
  (contains? birds 0))

(defn n-days-count [birds n]
  (reduce + (take n birds)))

(defn busy-days [birds]
  )

(defn odd-week? [birds]
  )
