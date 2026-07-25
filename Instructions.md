## Use below code for taking console input

# public static int[] TakeIntegerArrayInput()
# {
#     Console.WriteLine("Enter input array (Space separated numbers):");
#     var inputArr = Console.ReadLine();
#     
#     return [.. inputArr.Split(' ').Select(int.Parse)];
# }
# 
# public static int TakeNumberInput()
# {
#     Console.WriteLine("Enter number:");
#     var input = Console.ReadLine();
# 
#     return int.Parse(input);
# }