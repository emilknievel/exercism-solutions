raindrops <- function(number) {
  str <- ""

  if (number %% 3 == 0) str <- paste0(str, "Pling")
  if (number %% 5 == 0) str <- paste0(str, "Plang")
  if (number %% 7 == 0) str <- paste0(str, "Plong")

  if (nchar(str) > 0) return(str)

  return(as.character(number))
}
