aFunction = fn
  (param1, param2) when is_binary(param1) and is_binary(param2) ->
    param1 <> param2
  (param1, param2) when is_number(param1) and is_number(param2) ->
    param1 + param2
end

IO.puts(aFunction.(1, 2))
IO.puts(aFunction.("Hello ", "World"))
