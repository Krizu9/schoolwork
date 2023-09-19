integer1=154
integer2=78
divided=integer1/integer2
IO.puts "The result of #{integer1} divided by #{integer2} is #{divided}"

roundedToNearestInteger=round(divided)
IO.puts "The result of #{integer1} divided by #{integer2} rounded to the nearest integer is #{roundedToNearestInteger}"

firstInteger=trunc(divided)
IO.puts "The result of #{integer1} divided by #{integer2} truncated to the nearest integer is #{firstInteger}"
