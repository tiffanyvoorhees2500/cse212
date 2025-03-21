using System.Diagnostics;
using System.Security;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // List to hold the result to return
        var pairs = new List<string>();
        // HashSet to allow checking reverse word exists in words
        var wordsSet = new HashSet<string>(words);
        // HashSet to make sure we don't duplicate
        var pairsSet = new HashSet<string>();

        foreach (var word in words)
        {
            var reverseWord = new string([word[1], word[0]]);

            if (word != reverseWord && !pairsSet.Contains(word) && !pairsSet.Contains(reverseWord))
            {
                if (wordsSet.Contains(reverseWord))
                {
                    pairsSet.Add(word);
                    pairsSet.Add(reverseWord);
                    pairs.Add(word + " & " + reverseWord);
                }
            }
        }

        return pairs.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            var degree = fields[3];
            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // Make words lowercase and remove spaces
        var cleanWord1 = word1.ToLower().Replace(" ", "");
        var cleanWord2 = word2.ToLower().Replace(" ", "");
        if (cleanWord1.Length != cleanWord2.Length)
        {
            return false;
        }

        // ATTEMPT #2... Using 1 loop to compare letters in both words
        // Efficiency is O(n), but only has 1 loop, maybe that makes a difference. (using for instead of foreach to have access to index)

        // Does not pass the efficiency test, but Brother Kunz said as long as it is O(n) it should be fine
        var charCount = new Dictionary<char, int>();

        for (var i = 0; i < cleanWord1.Length; i++)
        {
            if (charCount.ContainsKey(cleanWord1[i]))
            {
                charCount[cleanWord1[i]]++;
            }
            else
            {
                charCount[cleanWord1[i]] = 1;

            }
            if (charCount.ContainsKey(cleanWord2[i]))
            {
                charCount[cleanWord2[i]]--;
            }
            else
            {
                charCount[cleanWord2[i]] = -1;
            }
        }

        foreach (var count in charCount.Values)
        {
            if (count != 0)
            {
                return false;
            }
        }

        return true;

        // Leaving the other attempts so that I can reference them later if needed...
        // ATTEMPT #3... Using an int[] instead of a dictionary, because research shows it is more efficient, BUT
        //  the instructions say we need to use a dictionary...???

        // Efficiency is 0(n)... This one passes the efficiency test, but not the instructions

        // int[] charCount = new int[256]; // Assuming ASCII characters

        // for (int i = 0; i < cleanWord1.Length; i++)
        // {
        //     charCount[cleanWord1[i]]++; // Increment for Word 1
        //     charCount[cleanWord2[i]]--; // Decrement for Word 2
        // }
        // // Check if all counts are zero
        // foreach (var count in charCount)
        // {
        //     if (count != 0)
        //     {
        //         return false;
        //     }
        // }

        // return true;

        // ATTEMPT #1... Using 2 loops to first put letters in a dictionary then compare 
        // Efficiency is O(2n) => O(n)

        // foreach (var letter in cleanWord1)
        // {
        //     if (charCount.ContainsKey(letter))
        //     {
        //         charCount[letter]++;
        //     }
        //     else
        //     {
        //         charCount[letter] = 1;
        //     }
        // }

        // foreach (var letter in cleanWord2)
        // {
        //     if (charCount.ContainsKey(letter))
        //     {
        //         charCount[letter]--; // Found match, reduce count of letter in dictionary
        //         if (charCount[letter] == 0)
        //         {
        //             charCount.Remove(letter); // We have reached the max number of occurrences allowed for this letter
        //         }
        //     }
        //     else
        //     {
        //         return false; // Found a letter in word2 that is not in word1
        //     }
        // }

        // If there are still items in the dictionary, then the words are not anagrams
        // if (charCount.Count != 0)
        // {
        //     return false;
        // }

        // return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // Loop through each feature and return the place and magnitude in string format
        return featureCollection.Features.Select(feature => $"{feature.Properties.Place} - Mag {feature.Properties.Mag}").ToArray();

    }
}