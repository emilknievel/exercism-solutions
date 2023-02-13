(ns cars-assemble)

(def cars 221)

(defn production-rate
  "Returns the assembly line's production rate per hour,
   taking into account its success rate"
  [speed]
  (cond (= speed 0) 0.0
        (and (> speed 0)
             (< speed 5)) (float (* speed cars))
        (and (> speed 4)
             (< speed 9)) (* speed cars 0.9)
        (= speed 9) (* speed cars 0.8)
        (= speed 10) (* speed cars 0.77)))

(defn working-items
  "Calculates how many working cars are produced per minute"
  [speed]
  )
