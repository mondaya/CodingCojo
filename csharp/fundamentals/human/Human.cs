namespace Human{


    public class Human 
    {   
        public Human(){
            Strength = 3;
            Intelligence = 3;
            Dexerity = 3;
            Health = 100;

        }

        public Human(string name){
            Name = name;
        }

        public Human(string name, int strength, int intelligence, int dexerity, int health)
        {
            Name = name;
            Strength = strength;
            Intelligence = intelligence;
            Dexerity = dexerity;
            Health = health;
        }

        public string Name {get; set;}
        public int Strength {get; set;}

        public int Intelligence {get; set;}
        public int Dexerity {get; set;}
        public int Health {get; set;}

        public void acttack(object opponent){
            if (opponent is Human) {
                int damage = 5 * Strength;
                ((Human)opponent).Health =- damage;
            }
        }

    }

}