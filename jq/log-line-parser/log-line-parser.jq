def trim: sub("^\\s+"; "") | sub("\\s+$"; "");

# Get message from a log line
def message:
  split(":")[1:] | join(":") | trim
;

# Get log level from a log line
def log_level:
  split(":")[0][1:-1] | ascii_downcase
;

# Reformat a log line
def reformat:
  message + " (" + log_level + ")"
;
