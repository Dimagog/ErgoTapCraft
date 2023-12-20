def cond [cond: bool, clo, els?] {
  if $cond {
    do $clo
  } else if $els != null {
    do $els
  } else {
    $in
  }
}

const shift = {
  "1": "!",
  "2": "@",
  "3": "#",
  "4": "$",
  "5": "%",
  "6": "^",
  "7": "&",
  "8": "*",
  "9": "(",
  "0": ")",
  "-": "_",
  "=": "+",
  "[": "{",
  "]": "}",
  "\\": "|",
  ";": ":",
  "'": "\"",
  ",": "<",
  ".": ">",
  "/": "?",
  "`": "~",
  "A": "a",
  "B": "b",
  "C": "c",
  "D": "d",
  "E": "e",
  "F": "f",
  "G": "g",
  "H": "h",
  "I": "i",
  "J": "j",
  "K": "k",
  "L": "l",
  "M": "m",
  "N": "n",
  "O": "o",
  "P": "p",
  "Q": "q",
  "R": "r",
  "S": "s",
  "T": "t",
  "U": "u",
  "V": "v",
  "W": "w",
  "X": "x",
  "Y": "y",
  "Z": "z",
}

def translate_shift [s] {
  if $s =~ 'Shift \+ ' {
    let combo = $s | split row ' + '
    let $len = $combo | length
    let key = $combo | get ($len - 1)
    let tr = $shift | get -i $key
    if $tr != null {
      $combo | take ($len - 1) | filter { $in != "Shift" } | append  $tr | str join " + "
    } else {
      $s
    }
  } else {
    $s
  }
}

export def main [
  file: string = mykeys.log  # file to analyze
  --letters             # include letters
  --lr                  # preserve Left/Right for modifiers (Shift, Ctrl, Alt, Win)
  --split-combos (-s)   # split combos into separate keys and count every key separately
  --trsh                # translate Shift+key, e.g. Shift+1 -> !
  --nl                  # no limit, don't filter out keys with less than 10 presses
] {
  let raw = ( open --raw $file
  | lines
  | cond (not $lr) { each { str replace -a -r '(Left|Right) (Ctrl|Shift|Alt|Win)' '${2}' } }
  | cond (not $letters) { filter { $in !~ '^[A-Z]$' } }
  | cond $trsh { each { translate_shift $in } }
  | cond (not $letters) { filter { $in !~ '^[a-z]$' } }
  )

  let res = if $split_combos {
    let alone = ( $raw
    | where $it !~ ' \+ '
    | str trim
    | histogram
    | rename key aloneCount
    | select key aloneCount
    )
    let inCombos = ( $raw
    | where $it =~ ' \+ '
    | split row ' + '
    | str trim
    | histogram
    | rename key comboCount
    | select key comboCount
    )

    ( $alone
    | join -o $inCombos key
    | default 0 aloneCount
    | default 0 comboCount
    | insert totalCount { $in.aloneCount + $in.comboCount }
    | sort-by -r totalCount aloneCount
    | move totalCount --after key
    | cond (not $nl) { where totalCount >= 10 }
    | insert comboPer { $in.comboCount * 100 / $in.totalCount }
    )
  } else {
    ( $raw
    | str trim
    | histogram
    | rename key count
    | cond $trsh { update key {translate_shift $in } }
    | cond (not $nl) { where count >= 10 }
    )
  }

  ( $res
  | cond (not $letters) { where key !~ '^[A-Za-z]$' }
  | where key not-in ["Unicode Keystroke" "UNKNOWN_FF"]
  )
}
