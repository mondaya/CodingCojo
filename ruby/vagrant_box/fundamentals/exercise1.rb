# just exercise

=begin
    long comment
    another comment
    another comment
=end
    
BEGIN {
    puts "this is in the begin block"
}

END{
    puts "this is in the end block"
}


puts "hello"
puts "Coding"
puts "Dojo"


print "hello"
print "Coding"



x  = 5

y =  10

z = x * y

puts z



first_name = "Monday"
last_name =  "Choi"

puts "Your name is " , first_name, last_name


puts "First name is #{first_name} and last name is #{last_name}"

puts "First name is %s and last name is %s" % [first_name, last_name]


z = 50

puts "Value of z is %d" %z



a = "hello "
a << "world"   #=> "hello world"
a.concat(33)   #=> "hello world!"


def guess_number guess
    number = 45
    # your code heref
    puts "Too High" unless guess < number;
    puts "Too Low"  unless guess > number;
    puts "You Got it!" unless guess != number;
end 

guess_number 50;



i = 0
num = 5
while i < num do
  puts "Inside the loop i = #{i}"
  i += 1  
  break if i == 2  
end


for i in 0..5 
  next if i == 2
  puts "Value of local variable is #{i}"   
end
