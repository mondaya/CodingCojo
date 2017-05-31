players = Player.all

players.each do |player| 
    puts player.name
    puts "team name, mascot and stadium -> #{player.team.name} , #{player.team.mascot}, #{player.team.stadium}"
end

#453 queries * 2

players = Player.includes(:team).all
players.each do |player| 
    puts player.name
    puts "team name, mascot and stadium -> #{player.team.name} , #{player.team.mascot}, #{player.team.stadium}"
end
#453


players = Player.includes(:team).where('team.name = "Chicago Bulls"')
players.each do |player| 
    puts player.name
    puts "team name, mascot and stadium -> #{player.team.name} , #{player.team.mascot}, #{player.team.stadium}"
end

