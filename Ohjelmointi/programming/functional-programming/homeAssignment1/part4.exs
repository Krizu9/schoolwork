function = fn a, b, c -> a * b * c end

IO.puts("Enter first integer: ")
integer1 = String.to_integer(String.trim(IO.gets("")))

IO.puts("Enter second integer: ")
integer2 = String.to_integer(String.trim(IO.gets("")))

IO.puts("Enter third integer: ")
integer3 = String.to_integer(String.trim(IO.gets("")))

result = function.(integer1, integer2, integer3)
IO.puts("The result of #{integer1} multiplied by #{integer2} multiplied by #{integer3} is #{result}")


concatFunction = fn list1, list2 -> list1 ++ list2 end

numbers1 = [1,2,3]
numbers2 = [4,5,6]

concatResult = concatFunction.(numbers1, numbers2)

IO.puts("The result of concatenating #{inspect numbers1} and #{inspect numbers2} is #{inspect concatResult}")

tuples = {:ok, :fail}

newTuple = {:canceled, elem(tuples, 0), elem(tuples, 1)}

IO.inspect(newTuple)
