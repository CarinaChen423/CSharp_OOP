using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class DataStorage
{
    public static string fileOfDonors = Path.GetFullPath(@"..\..\Resources\File of Donors.txt");

    public static List<string[]> ReadDonorData()
    {
        List<string[]> donorData = new List<string[]>();

        if (File.Exists(fileOfDonors))
        {
            donorData = File.ReadAllLines(fileOfDonors)
                .Select(line => line.Split(';'))
                .ToList();
        }

        return donorData;
    }

    public static void WriteDonorData(List<string[]> donorData)
    {
        File.WriteAllLines(fileOfDonors, donorData.Select(donor => string.Join(";", donor)));
    }
}

public class Donor
{
    private static List<string[]> donorData;

    static Donor()
    {
        donorData = DataStorage.ReadDonorData();
    }

    public static void AddDonor(string[] donor)
    {
        donorData.Add(donor);
        DataStorage.WriteDonorData(donorData);
    }

    public static void RemoveDonor(int index)
    {
        if (index >= 0 && index < donorData.Count)
        {
            donorData.RemoveAt(index);
            DataStorage.WriteDonorData(donorData);
        }
    }

    public static List<string[]> GetAllDonors()
    {
        return donorData;
    }
}
