use Stats.nu

export def main [
    file?: string  # file to analyze
] {
  (Stats --trsh -s --nl $file
  | sort-by -r comboPer
  | where key !~ "Arrow" and key not-in [Ctrl Shift Alt Win] and comboCount >= 10
  )
}
