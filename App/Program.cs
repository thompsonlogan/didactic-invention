namespace App
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Input directions");
                string? input = Console.ReadLine();
                double distance = CalculateDistance(input); // 15F6B6B5L16R8B16F20L6F13F11R
                Console.WriteLine("The Euclidean distance from the starting point to the destination is: " + distance);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public static double CalculateDistance(string directions)
        {
            int x = 0, y = 0;
            string distanceStr = "";

            if (string.IsNullOrWhiteSpace(directions))
                throw new ArgumentNullException("Directions cannot be null or empty.");
        
            foreach (char direction in directions)
            {
                if (char.IsDigit(direction))
                {
                    distanceStr += direction;
                }
                else if (char.IsLetter(direction))
                {
                    if (string.IsNullOrEmpty(distanceStr)) 
                        throw new ArgumentException("Invalid input format: missing distance.");

                    int distance = int.Parse(distanceStr);
                    distanceStr = ""; // reset distance string
                
                    switch (direction)
                    {
                        case 'F': // forward
                            x += distance;
                            break;
                        case 'B': // back
                            x -= distance;
                            break;
                        case 'R': // right
                            y += distance;
                            break;
                        case 'L': // left
                            y -= distance;
                            break;
                        default:
                            throw new ArgumentException($"Invalid direction: {direction}");
                    }
                }
                else // invalid character
                    throw new ArgumentException($"Invalid character: {direction}");
            }

            // if input ends with a remaining distance and no direction
            if (!string.IsNullOrEmpty(distanceStr))
                throw new ArgumentException("Invalid input format: incomplete instruction.");

            return Math.Sqrt((x * x) + (y * y));
        }
    }
}