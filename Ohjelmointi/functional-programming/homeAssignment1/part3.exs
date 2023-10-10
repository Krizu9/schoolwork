IO.puts("Enter a line of text: ")
userInput = IO.gets("")

if userInput = "foo" do
  IO.puts("bar")
else
  trimmedInput = String.trim(userInput)
  characterCount = String.length(trimmedInput)
  IO.puts("Number of characters entered: #{characterCount}")
  reversedInput = String.reverse(trimmedInput)
  IO.puts("Reversed input: #{reversedInput}")
end
