using static System.Console;
// Player init
int playerGold = 100;
string playerCurrentWeapon = "Sword";
int playerCurrentHealth = 100;
string playerName;

// Scene 1: Entering Town for the first time
Write("""
            Hello traveler! Welcome to town! My name is Barnaby, and I am the Newbie Guide here in town.
            What is your name? (Type your name): 
            """);
playerName = ReadLine()!;
WriteLine($"""
            Hello {playerName}! It's so wonderful to meet you!
            Since you are new, I suggest doing one of the following:
            """);
string[] beginnerList = ["Take on the Beginner Boss Battle","Help the King with an important task"];

for (int i = 0; i < beginnerList.Length; i++)
        {
            Write(beginnerList[i]);

            if (i < beginnerList.Length - 1)
            {
                Write(" or ");
            }
        }
WriteLine();
Write("Which do you choose? (Type 1-2): ");
string selection = ReadLine()!;
int selectionInt = int.Parse(selection!);
selectionInt--;
WriteLine($"You've chosen to {beginnerList[selectionInt]}.");
WriteLine($"""
            It was so nice for you to help out, {playerName}! Here's 100 gold to get you started. 
            Now off you go on your adventure!
            """);
WriteLine(); // Boss Battle
if (selectionInt == 0)
{
    int opponentHealth = 100;
    WriteLine($"""
            Hello {playerName}, and welcome to the Beginner Boss Battle.
            You have {playerCurrentHealth} health, and your opponent has {opponentHealth} health.
            You get the first attack.
            """);
    string[] attackOption = ["Overhead Strike", "Slash", "Stab"];
    while (opponentHealth > 0)
    {
        for (int s = 0; s < attackOption.Length; s++)
        {
            Write(attackOption[s]);

            if (s < attackOption.Length - 1)
            {
                Write(", ");
            }
        }
        WriteLine();
        Write("Which attack do you choose? (Type 1-3): ");
        string attack = ReadLine()!;
        int attackInt = int.Parse(attack);
        attackInt--;
        string attackChoice = attackOption[attackInt];
        int opponentDamageTaken;
        if (attackInt == 0)
        {
            opponentDamageTaken = Random.Shared.Next(29,33);
            opponentHealth -= opponentDamageTaken;
        }
        else if (attackInt == 1)
        {
            opponentDamageTaken = Random.Shared.Next(24,27);
            opponentHealth -= 26;
        }
        else
        {
            opponentDamageTaken = Random.Shared.Next(21,24);
            opponentHealth -= 23;
        }
        if (opponentHealth < 0)
        {
            opponentHealth = 0;
        }
        WriteLine($"Your {attackChoice} did {opponentDamageTaken} damage! You're opponent is now at {opponentHealth} health.");
        int opponentDamage = Random.Shared.Next(15, 24);
        if (opponentHealth == 0)
        {
            break;
        }
        playerCurrentHealth -= opponentDamage;
        WriteLine($"Your opponent returned {opponentDamage} damage and you're now at {playerCurrentHealth} health.");
    }
    playerGold += 500;
    WriteLine($"""
                Congratulations on beating the boss, {playerName}! You did an amazing job!
                You are awarded 500 gold, putting you at {playerGold} gold!
                """);
WriteLine();

}
else // King's Task
{
    WriteLine("Your task: Give the King's pet dog some food.");
    string[] dogFood = ["Chicken", "Beef", "Turkey", "Lamb"];
    WriteLine("The different types of dog food include:");
    for (int s = 0; s < dogFood.Length; s++)
    {
        Write(dogFood[s]);

        if (s < dogFood.Length - 1)
        {
            Write(", ");
        }
    }
    WriteLine();
    WriteLine("Which do you want to feed the King's dog? (Type 1-4): ");
    string dogFoodOption = ReadLine()!;
    int dogFoodInt = int.Parse(dogFoodOption);
    dogFoodInt--;
    string dogFoodChoice = dogFood[dogFoodInt];
    WriteLine($"You gave the King's dog {dogFoodChoice} to eat.");
    playerGold += 100;
    WriteLine($"The King deeply appreciates your help. He has awarded you 100 gold, putting you at {playerGold} gold.");
    WriteLine();
}

WriteLine("You have entered the Weapons Shop.");
WriteLine();
// Weapons Shop
string[] weapons = ["Mace","Crossbow","Spear","Longsword","Axe"];
if (playerGold > 200)
{
WriteLine($"""
        Hello {playerName}, and welcome to the Weapons Shop. I'm the Weaponsmith.
        It seems like you can afford any weapon you want with your {playerGold} gold.
        """);
DisplayWeapons(weapons);
}
else
{
    WriteLine($"""
                Hello {playerName}, and welcome to the Weapons shop. I'm the Weaponsmith.
                With your {playerGold} gold, you can afford the Mace, Crossbow, Spear, or Axe.
                """);
}
WriteLine("Would you like to buy a new weapon?");
string response = ReadLine()!;
if (response == "Yes"|| response == "yes")
    {
        Write("""
                Great! The Mace is worth 200 gold, the Crossbow is worth 135 gold, the Spear is worth 175 gold,
                the Longsword is worth 250 gold, and the Axe is worth 125 gold.
                Which weapon would you like to purchase? (Type 1-5): 
                """);
        string weaponSelection = ReadLine()!;
        //Changes the player's current weapon.
        int playerWeaponSelection = int.Parse(weaponSelection!);
        playerWeaponSelection--;
        playerCurrentWeapon = weapons[playerWeaponSelection];
        if (playerWeaponSelection == 0)
        {
            playerGold -= 200;
        }
        else if (playerWeaponSelection == 1)
        {
            playerGold -= 135;
        }
        else if (playerWeaponSelection == 2)
        {
            playerGold -= 175;
        }
        else if (playerWeaponSelection == 3)
        {
            playerGold -= 250;
        }
        else
        {
            playerGold -= 125;
        }
        if (playerGold < 0)
        {
            WriteLine($"Looks like you can't afford that. Do you wish to choose a different one?");
            response = ReadLine()!;
            if (response == "yes" || response == "Yes")
            {
                DisplayWeapons(weapons);
                WriteLine("Which do you choose? (Type 1-4): ");
                weaponSelection = ReadLine()!;
                playerWeaponSelection = int.Parse(weaponSelection!);
            playerWeaponSelection--;
            playerCurrentWeapon = weapons[playerWeaponSelection];
            if (playerWeaponSelection == 0)
            {
                playerGold -= 200;
            }
            else if (playerWeaponSelection == 1)
            {
                playerGold -= 135;
            }
            else if (playerWeaponSelection == 2)
            {
                playerGold -= 175;
            }
            else if (playerWeaponSelection == 3)
            {
                playerGold -= 250;
            }
            else
            {
                playerGold -= 125;
            }
            }
        }


    WriteLine($"You're current weapon is now '{playerCurrentWeapon}' and you have {playerGold} gold remaining.");

    }
else
{
    WriteLine($"No worries, {playerName}. You still have {playerGold} gold. Come back whenever you want!");
}
WriteLine(); //End of Game
WriteLine($"""
            You've reached the end of the game. Thanks for playing, {playerName}!
            I hope you had a good time. Come back if you ever want to play again!
            """);

//Weapons Shop Function
void DisplayWeapons(string[] weapons)
{
    WriteLine("The weapons I currently have available include:");

    for (int s = 0; s < weapons.Length; s++)
    {
        Write(weapons[s]);

        if (s < weapons.Length - 1)
        {
            Write(", ");
        }
    }

    WriteLine();
}
