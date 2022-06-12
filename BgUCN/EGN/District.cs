namespace UCN
{
    using System.Collections.Generic;
    using System.Linq;
    public class District
    {
        private readonly Dictionary<string, IEnumerable<int>> districts;
        private readonly Dictionary<IEnumerable<int>, string> districtsCodes;

        public District()
        {
            this.districts = new Dictionary<string, IEnumerable<int>>()
                {
                { "Blagoevgrad", Enumerable.Range(0, 44) },
                { "Burgas", Enumerable.Range(44, 50) },
                { "Varna", Enumerable.Range(94, 46) },
                { "Veliko Tarnovo", Enumerable.Range(140, 30) },
                { "Vidin", Enumerable.Range(170, 14) },
                { "Vratsa", Enumerable.Range(184, 34) },
                { "Gabrovo", Enumerable.Range(218, 16) },
                { "Kardzhali", Enumerable.Range(234, 48) },
                { "Kyustendil", Enumerable.Range(282, 20) },
                { "Lovech", Enumerable.Range(302, 18) },
                { "Montana", Enumerable.Range(320, 22) },
                { "Pazardzhik", Enumerable.Range(342, 36) },
                { "Pernik", Enumerable.Range(378, 18) },
                { "Pleven", Enumerable.Range(396, 40) },
                { "Plovdiv", Enumerable.Range(436, 66) },
                { "Razgrad", Enumerable.Range(502, 26) },
                { "Ruse", Enumerable.Range(528, 28) },
                { "Silistra", Enumerable.Range(556, 20) },
                { "Sliven", Enumerable.Range(576, 26) },
                { "Smolyan", Enumerable.Range(602, 22) },
                { "Sofia City", Enumerable.Range(624, 98) },
                { "Sofia District", Enumerable.Range(722, 30) },
                { "Stara Zagora", Enumerable.Range(752, 38) },
                { "Dobrich", Enumerable.Range(790, 32) },
                { "Targovishte", Enumerable.Range(822, 22) },
                { "Haskovo", Enumerable.Range(844, 28) },
                { "Shumen", Enumerable.Range(872, 32) },
                { "Yambol", Enumerable.Range(904, 22) },
                { "Other/Unknown", Enumerable.Range(926, 73) },
                { "Unknown/Other", Enumerable.Range(999, 1) }
            };

            this.districtsCodes = new Dictionary<IEnumerable<int>, string>()
            {
                { Enumerable.Range(  0, 44), "Blagoevgrad" },
                { Enumerable.Range( 44, 50), "Burgas" },
                { Enumerable.Range( 94, 46), "Varna" },
                { Enumerable.Range(140, 30), "Veliko Tarnovo" },
                { Enumerable.Range(170, 14), "Vidin" },
                { Enumerable.Range(184, 34), "Vratsa" },
                { Enumerable.Range(218, 16), "Gabrovo" },
                { Enumerable.Range(234, 48), "Kardzhali" },
                { Enumerable.Range(282, 20), "Kyustendil" },
                { Enumerable.Range(302, 18), "Lovech" },
                { Enumerable.Range(320, 22), "Montana" },
                { Enumerable.Range(342, 36), "Pazardzhik" },
                { Enumerable.Range(378, 18), "Pernik" },
                { Enumerable.Range(396, 40), "Pleven" },
                { Enumerable.Range(436, 66), "Plovdiv" },
                { Enumerable.Range(502, 26), "Razgrad" },
                { Enumerable.Range(528, 28), "Ruse" },
                { Enumerable.Range(556, 20), "Silistra" },
                { Enumerable.Range(576, 26), "Sliven" },
                { Enumerable.Range(602, 22), "Smolyan" },
                { Enumerable.Range(624, 98), "Sofia City" },
                { Enumerable.Range(722, 30), "Sofia District" },
                { Enumerable.Range(752, 38), "Stara Zagora" },
                { Enumerable.Range(790, 32), "Dobrich" },
                { Enumerable.Range(822, 22), "Targovishte" },
                { Enumerable.Range(844, 28), "Haskovo" },
                { Enumerable.Range(872, 32), "Shumen" },
                { Enumerable.Range(904, 22), "Yambol" },
                { Enumerable.Range(926, 73), "Other/Unknown" },
                { Enumerable.Range(999, 1), "Unknown/Other" }
            };
        }

        public Dictionary<string, IEnumerable<int>> Districts => this.districts;

        public string GetDistrictByCode(int code)
        {
            foreach (var collection in districtsCodes.Keys)
            {
                if (collection.Contains(code))
                {
                    return districtsCodes[collection];
                }
            }

            return null;
        }

        public List<int> GetCodeRangeByDistrict(string district)
        {
            return districts[district].ToList();
        }
    }
}
