a = %w{cat dog bear}; puts a.values_at(1,2).join(' and ') #=> "dog and bear"





my_arr = ["coding", "dojo", "seattle",  "sanfrancisco"]

puts my_arr.at(0)
puts
puts my_arr.fetch(0)
puts
puts my_arr.delete 3
puts
puts my_arr.reverse
puts
puts my_arr.length
puts
puts my_arr.sort
puts my_arr.slice 0, 3
puts
puts my_arr.shuffle
puts
puts my_arr.join "-"
puts
puts my_arr.insert -1, "chicago"


