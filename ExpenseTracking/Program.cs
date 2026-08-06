namespace ExpenseTracking {
    enum ApprovalStage {Draft, Submitted, Rejected, Approved, UnderReview}
    [Flags]
    enum ExpenseType {None = 0, Travel= 1, Meals = 2, OfficeSupplies=4, Software=8, Entertainment=16}

    class Program {
        static void Main(){
            string[] expenseTypes = Enum.GetNames(typeof(ExpenseType));
            foreach(string expenseType in expenseTypes){
                Console.WriteLine(expenseType);
            }
            ExpenseType expenses = ExpenseType.Travel | ExpenseType.Meals;
            if(expenses.HasFlag(ExpenseType.Meals)){
                Console.WriteLine($"Expenses includes: {ExpenseType.Meals}");
            }else {
                Console.WriteLine("Expense does not include: Meals");
            }
            expenses &= ~ExpenseType.Meals;
            Console.WriteLine($"New updated expenses: {expenses} only left.");
            string input = "Meals | Software";
            ExpenseType output;
            bool success = Enum.TryParse(input, out output);
            
            if(success){
                Console.WriteLine(output);
            }else {
                // throw new InvalidOperationException($"{input} is not a valid input");
                Console.WriteLine($"Error: {input} is not a valid input");
            }

            Array approvalValues = Enum.GetValues(typeof(ApprovalStage));
            foreach(ApprovalStage value in approvalValues){
                Console.WriteLine($"Text: {value} and value: {(int)value}");
            }
            string inputStatus = "Submitted";
            ApprovalStage parsedStage;
            bool statusChanged = Enum.TryParse(inputStatus, out parsedStage);
           
            if(statusChanged){
                Console.WriteLine(statusChanged);
            } else {
                Console.WriteLine("Error: Could not convert status!");
            }
            int approvalValue = 4;
            if(Enum.IsDefined(typeof(ApprovalStage), approvalValue)){
                ApprovalStage newValue = (ApprovalStage)approvalValue;
                Console.WriteLine(newValue);
            }
            else {
                Console.WriteLine($"Error:{approvalValue} is not defined");
            }
            ApprovalStage currentStage = ApprovalStage.UnderReview;

            switch (currentStage) {
                case ApprovalStage.Draft:
                    Console.WriteLine("Expense report has been drafted!");
                    break;
                case ApprovalStage.UnderReview:
                    Console.WriteLine("Expense report is under review.");
                    break;
                case ApprovalStage.Rejected:
                    Console.WriteLine("Expense report has been rejected!");
                    break;
                case ApprovalStage.Approved:
                    Console.WriteLine("Expense report has been approved");
                    break;
                default:
                    Console.WriteLine("Stage not specified yet.");
                    break;
        }
         ExpenseType validExpense = ExpenseType.OfficeSupplies | ExpenseType.Software;
         if(Enum.IsDefined(typeof(ExpenseType), "Meals")){
            Console.WriteLine("It is a valid expense type!");
         } else {
            Console.WriteLine("Error: meals is not a valid expense type!");
         }
         currentStage = ApprovalStage.Approved;
         Console.WriteLine("Expense is {0}", validExpense);
         Console.WriteLine("Final stage {0}", currentStage);
            
        }
    }
}
