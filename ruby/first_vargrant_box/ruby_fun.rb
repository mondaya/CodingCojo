arr = ["I", "code", "therefore", "I", "am"]
for i in 0...arr.count
  puts arr[i]
end


if ""
  puts "I am positive"
end
if 0
  puts "I am positive"
end


unless nil
  puts "I am negative"
end
unless false
  puts "I am negative"
end




#Inline Conditionals

#We can write an if/unless statement in one line. So beautiful.

puts "I am positive" if "hello"
puts "I am positive" if 24
puts "I am negative" unless nil
puts "I am negative" unless false
