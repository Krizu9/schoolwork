IO.puts("Enter a number: ")
input = String.trim(IO.gets(""))
input = String.to_integer(input)

if rem(input, 3) == 0 do
  IO.puts("Divisible by 3")
else
  if rem(input, 5) == 0 do
    IO.puts("Divisible by 5")
  else
    if rem(input, 7) == 0 do
      IO.puts("Divisible by 7")
    else
      if rem(input, 2) == 0 do
        IO.puts("Divisible by 2")
      end
    end
  end
end
