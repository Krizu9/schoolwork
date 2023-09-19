integerVariable = 123
IO.puts(integerVariable)

IO.puts("Enter anything: ")
userInput = IO.gets("")

IO.puts("You typed: #{userInput}")

combinedValue = "#{integerVariable}#{userInput}"

IO.puts(combinedValue)
