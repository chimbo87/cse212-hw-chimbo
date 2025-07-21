using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> seen = new HashSet<string>();
        List<string> pairs = new List<string>();

        foreach (string word in words)
        {
            if (word[0] == word[1]) continue;

            string reversed = $"{word[1]}{word[0]}";
            if (seen.Contains(reversed))
            {
                pairs.Add($"{reversed} & {word}");
            }
            else
            {
                seen.Add(word);
            }
        }

        return pairs.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');
            var degree = fields[3].Trim();

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

    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length) return false;

        Dictionary<char, int> charCount = new Dictionary<char, int>();

        foreach (char c in word1)
        {
            if (charCount.ContainsKey(c))
                charCount[c]++;
            else
                charCount[c] = 1;
        }

        foreach (char c in word2)
        {
            if (!charCount.ContainsKey(c) || charCount[c] == 0)
                return false;
            charCount[c]--;
        }

        return true;
    }

    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<EarthquakeFeatureCollection>(json, options);

        return featureCollection.Features
            .Select(f => $"{f.Properties.Place} - Mag {f.Properties.Mag}")
            .ToArray();
    }
}

// Earthquake-specific classes
public class EarthquakeFeatureCollection
{
    public EarthquakeFeature[] Features { get; set; }
}

public class EarthquakeFeature
{
    public EarthquakeProperty Properties { get; set; }
}

public class EarthquakeProperty
{
    public string Place { get; set; }
    public double Mag { get; set; }
}