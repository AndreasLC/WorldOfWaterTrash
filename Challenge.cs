class Challenge {

//Attributes
    private List<Question> questions;
    private Inventory inventory;
    private List<Item> predefinedItems;
    private int currentItemIndex;

//Constructor
    //Adds a list of question
    public Challenge(){
        questions = new List<Question>();
    }

//Methods
    //A list of all obtainable items
    private List<Item> GetChallengeItems()
    {
        return new List<Item>
        {
            new Item("Bottle cap", "Ingested by marine life, leading to injuries and contributing to microplastics.", 1),
            new Item("Plastic bag", "Causes suffocation and digestive blockages in sea turtles and other creatures.", 2),
            new Item("Fishing gear", "Abandoned gear entangles marine animals, causing injury and death.", 3),
            new Item("Plastic straw", "Blockages and harm from ingestion by marine animals.", 4),
            new Item("Cigarette butts", "Toxic chemicals leach into the water, harming marine life.", 5),
            new Item("Balloon", "Balloons and their strings cause ingestion and entanglement in marine creatures.", 6),
            new Item("Styrofoam box", "Breaks into small particles, causing ingestion and toxic exposure.", 7),
            new Item("Plastic wrapper", "Contributes to microplastics and is ingested by marine animals.", 8),
            new Item("Cutlery", "Ingested by marine life, causing internal damage and environmental pollution.", 9),
            new Item("Gill net", "Entangles and kills marine life, continuing to harm even when abandoned.", 10),
        };
    }


    public void beginChallenge() {
        shuffleQuestions();

        foreach (var question in questions) {
            question.QuestionDisplay();
            int inputUser = GetInputUser();
            if (question.IsCorrect(inputUser)){
                Item rewardItem = GetNextPredefinedItem();
                Console.WriteLine($"Your knowledge is increasing, you succesfully picked up the trash!");
                inventory.AddItem(rewardItem);
                inventory.InventoryDisplay();
                Console.WriteLine();
            }
            else {
                Console.WriteLine("Incorrect, try again!");
                //(Add a function here subtracting hp)
            }

            //Add hp checker here, for ending game if hp == 0
        }
    }

    //Randomizing question positions
    private void shuffleQuestions() {
        Random sequence = new Random();
        int n = questions.Count;
        while (n > 1) {
            n--;
            int k = sequence.Next(n + 1);
            Question number = questions[k];
            questions[k] = questions[n];
            questions[n] = number;
        }
    }

    //Reads the input from user and checks for syntax errors
    private int GetInputUser(){
        int choice;
        while (true) {
            Console.WriteLine("Enter your answer(number between 1 and 5):");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out choice) && choice >= 1 && choice <= 5) {
                break;
            }
            else {
                throw new Exception("Try again, please enter a number between 1 and 5.");
            }
        }
        return choice;
    }

    //Gives the next item in order from the list GetChallengeItem()
    private Item GetNextPredefinedItem(){
        if (currentItemIndex >= predefinedItems.Count){
            currentItemIndex = 0; //Resets to 0 if all items has been obtained
        }
        Item item = predefinedItems[currentItemIndex];
        currentItemIndex++; //Goes to the next item in the list for the next quiz
        return item;
    }
}