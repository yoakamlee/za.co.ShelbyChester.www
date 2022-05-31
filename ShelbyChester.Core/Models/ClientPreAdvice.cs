﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyChester.Core.Models
{
    public class ClientPreAdvice : BaseEntity
    {

        [Required(ErrorMessage = "Please enter information!")]
        [Display(Name = "Name")]
        public string Customer_Name { get; set; }

        [Required(ErrorMessage = "Please enter information!")]
        [Display(Name = "Surname")]
        public string Customer_Surname { get; set; }

        [Required(ErrorMessage = "Please enter information!")]
        [Display(Name = "Address")]
        public string Customer_Address { get; set; }

        [Required(ErrorMessage = "Please enter information!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        [Display(Name = "E-mail")]
        public string Customer_Email { get; set; }

        [Display(Name = "Cell Phone Number (Optional)")]
        public string Customer_CellNum { get; set; }

        [Required(ErrorMessage = "Please enter information!")]
        [Display(Name = "Number Of Items")]
        public int NumberOfItems { get; set; }

        [Required(ErrorMessage = "Please enter information!")]
        [Display(Name = "Individual Weight of item")]
        public int WeightOfItems { get; set; }

        [Display(Name = "Size per square meter (Optional)")]
        public string SizePerItem { get; set; }

        [Display(Name = "Description of items")]
        [StringLength(500, MinimumLength = 10)]
        public string Client_Description { get; set; }


        [Required(ErrorMessage = "Please Select Country!")]
        [Display(Name = "Country")]
        public Country Country { get; set; }

        [Required(ErrorMessage = "Please Select Container Type!")]
        [Display(Name = "Container Type")]
        public string ContainerType { get; set; }

        [Display(Name = "Select Province")]
        public Province Province { get; set; }

    }

    public enum Country
    {
        [Display(Name = "Afghanistan")] AF = 1,
        [Display(Name = "Åland Islands")] AX = 2,
        [Display(Name = "Albania")] AL = 3,
        [Display(Name = "Algeria")] DZ = 4,
        [Display(Name = "American Samoa")] AS = 5,
        [Display(Name = "Andorra")] AD = 6,
        [Display(Name = "Angola")] AO = 7,
        [Display(Name = "Anguilla")] AI = 8,
        [Display(Name = "Antarctica")] AQ = 9,
        [Display(Name = "Antigua and Barbuda")] AG = 10,
        [Display(Name = "Argentina")] AR = 11,
        [Display(Name = "Armenia")] AM = 12,
        [Display(Name = "Aruba")] AW = 13,
        [Display(Name = "Australia")] AU = 14,
        [Display(Name = "Austria")] AT = 15,
        [Display(Name = "Azerbaijan")] AZ = 16,
        [Display(Name = "Bahamas")] BS = 17,
        [Display(Name = "Bahrain")] BH = 18,
        [Display(Name = "Bangladesh")] BD = 19,
        [Display(Name = "Barbados")] BB = 20,
        [Display(Name = "Belarus")] BY = 21,
        [Display(Name = "Belgium")] BE = 22,
        [Display(Name = "Belize")] BZ = 23,
        [Display(Name = "Benin")] BJ = 24,
        [Display(Name = "Bermuda")] BM = 25,
        [Display(Name = "Bhutan")] BT = 26,
        [Display(Name = "Bolivia (Plurinational State of)")] BO = 27,
        [Display(Name = "Bonaire, Sint Eustatius and Saba")] BQ = 28,
        [Display(Name = "Bosnia and Herzegovina")] BA = 29,
        [Display(Name = "Botswana")] BW = 30,
        [Display(Name = "Bouvet Island")] BV = 31,
        [Display(Name = "Brazil")] BR = 32,
        [Display(Name = "British Indian Ocean Territory")] IO = 33,
        [Display(Name = "Brunei Darussalam")] BN = 34,
        [Display(Name = "Bulgaria")] BG = 35,
        [Display(Name = "Burkina Faso")] BF = 36,
        [Display(Name = "Burundi")] BI = 37,
        [Display(Name = "Cabo Verde")] CV = 38,
        [Display(Name = "Cambodia")] KH = 39,
        [Display(Name = "Cameroon")] CM = 40,
        [Display(Name = "Canada")] CA = 41,
        [Display(Name = "Cayman Islands")] KY = 42,
        [Display(Name = "Central African Republic")] CF = 43,
        [Display(Name = "Chad")] TD = 44,
        [Display(Name = "Chile")] CL = 45,
        [Display(Name = "China")] CN = 46,
        [Display(Name = "Christmas Island")] CX = 47,
        [Display(Name = "Cocos (Keeling) Islands")] CC = 48,
        [Display(Name = "Colombia")] CO = 49,
        [Display(Name = "Comoros")] KM = 50,
        [Display(Name = "Congo")] CG = 51,
        [Display(Name = "Congo (Democratic Republic of the)")] CD = 52,
        [Display(Name = "Cook Islands")] CK = 53,
        [Display(Name = "Costa Rica")] CR = 54,
        [Display(Name = "Côte d'Ivoire")] CI = 55,
        [Display(Name = "Croatia")] HR = 56,
        [Display(Name = "Cuba")] CU = 57,
        [Display(Name = "Curaçao")] CW = 58,
        [Display(Name = "Cyprus")] CY = 59,
        [Display(Name = "Czechia")] CZ = 60,
        [Display(Name = "Denmark")] DK = 61,
        [Display(Name = "Djibouti")] DJ = 62,
        [Display(Name = "Dominica")] DM = 63,
        [Display(Name = "Dominican Republic")] DO = 64,
        [Display(Name = "Ecuador")] EC = 65,
        [Display(Name = "Egypt")] EG = 66,
        [Display(Name = "El Salvador")] SV = 67,
        [Display(Name = "Equatorial Guinea")] GQ = 68,
        [Display(Name = "Eritrea")] ER = 69,
        [Display(Name = "Estonia")] EE = 70,
        [Display(Name = "Ethiopia")] ET = 71,
        [Display(Name = "Falkland Islands (Malvinas)")] FK = 72,
        [Display(Name = "Faroe Islands")] FO = 73,
        [Display(Name = "Fiji")] FJ = 74,
        [Display(Name = "Finland")] FI = 75,
        [Display(Name = "France")] FR = 76,
        [Display(Name = "French Guiana")] GF = 77,
        [Display(Name = "French Polynesia")] PF = 78,
        [Display(Name = "French Southern Territories")] TF = 79,
        [Display(Name = "Gabon")] GA = 80,
        [Display(Name = "Gambia")] GM = 81,
        [Display(Name = "Georgia")] GE = 82,
        [Display(Name = "Germany")] DE = 83,
        [Display(Name = "Ghana")] GH = 84,
        [Display(Name = "Gibraltar")] GI = 85,
        [Display(Name = "Greece")] GR = 86,
        [Display(Name = "Greenland")] GL = 87,
        [Display(Name = "Grenada")] GD = 88,
        [Display(Name = "Guadeloupe")] GP = 89,
        [Display(Name = "Guam")] GU = 90,
        [Display(Name = "Guatemala")] GT = 91,
        [Display(Name = "Guernsey")] GG = 92,
        [Display(Name = "Guinea")] GN = 93,
        [Display(Name = "Guinea-Bissau")] GW = 94,
        [Display(Name = "Guyana")] GY = 95,
        [Display(Name = "Haiti")] HT = 96,
        [Display(Name = "Heard Island and McDonald Islands")] HM = 97,
        [Display(Name = "Holy See")] VA = 98,
        [Display(Name = "Honduras")] HN = 99,
        [Display(Name = "Hong Kong")] HK = 100,
        [Display(Name = "Hungary")] HU = 101,
        [Display(Name = "Iceland")] IS = 102,
        [Display(Name = "India")] IN = 103,
        [Display(Name = "Indonesia")] ID = 104,
        [Display(Name = "Iran (Islamic Republic of)")] IR = 105,
        [Display(Name = "Iraq")] IQ = 106,
        [Display(Name = "Ireland")] IE = 107,
        [Display(Name = "Isle of Man")] IM = 108,
        [Display(Name = "Israel")] IL = 109,
        [Display(Name = "Italy")] IT = 110,
        [Display(Name = "Jamaica")] JM = 111,
        [Display(Name = "Japan")] JP = 112,
        [Display(Name = "Jersey")] JE = 113,
        [Display(Name = "Jordan")] JO = 114,
        [Display(Name = "Kazakhstan")] KZ = 115,
        [Display(Name = "Kenya")] KE = 116,
        [Display(Name = "Kiribati")] KI = 117,
        [Display(Name = "Korea (Democratic People's Republic of)")] KP = 118,
        [Display(Name = "Korea (Republic of)")] KR = 119,
        [Display(Name = "Kuwait")] KW = 120,
        [Display(Name = "Kyrgyzstan")] KG = 121,
        [Display(Name = "Lao People's Democratic Republic")] LA = 122,
        [Display(Name = "Latvia")] LV = 123,
        [Display(Name = "Lebanon")] LB = 124,
        [Display(Name = "Lesotho")] LS = 125,
        [Display(Name = "Liberia")] LR = 126,
        [Display(Name = "Libya")] LY = 127,
        [Display(Name = "Liechtenstein")] LI = 128,
        [Display(Name = "Lithuania")] LT = 129,
        [Display(Name = "Luxembourg")] LU = 130,
        [Display(Name = "Macao")] MO = 131,
        [Display(Name = "Macedonia (the former Yugoslav Republic of)")] MK = 132,
        [Display(Name = "Madagascar")] MG = 133,
        [Display(Name = "Malawi")] MW = 134,
        [Display(Name = "Malaysia")] MY = 135,
        [Display(Name = "Maldives")] MV = 136,
        [Display(Name = "Mali")] ML = 137,
        [Display(Name = "Malta")] MT = 138,
        [Display(Name = "Marshall Islands")] MH = 139,
        [Display(Name = "Martinique")] MQ = 140,
        [Display(Name = "Mauritania")] MR = 141,
        [Display(Name = "Mauritius")] MU = 142,
        [Display(Name = "Mayotte")] YT = 143,
        [Display(Name = "Mexico")] MX = 144,
        [Display(Name = "Micronesia (Federated States of)")] FM = 145,
        [Display(Name = "Moldova (Republic of)")] MD = 146,
        [Display(Name = "Monaco")] MC = 147,
        [Display(Name = "Mongolia")] MN = 148,
        [Display(Name = "Montenegro")] ME = 149,
        [Display(Name = "Montserrat")] MS = 150,
        [Display(Name = "Morocco")] MA = 151,
        [Display(Name = "Mozambique")] MZ = 152,
        [Display(Name = "Myanmar")] MM = 153,
        [Display(Name = "Namibia")] NA = 154,
        [Display(Name = "Nauru")] NR = 155,
        [Display(Name = "Nepal")] NP = 156,
        [Display(Name = "Netherlands")] NL = 157,
        [Display(Name = "New Caledonia")] NC = 158,
        [Display(Name = "New Zealand")] NZ = 159,
        [Display(Name = "Nicaragua")] NI = 160,
        [Display(Name = "Niger")] NE = 161,
        [Display(Name = "Nigeria")] NG = 162,
        [Display(Name = "Niue")] NU = 163,
        [Display(Name = "Norfolk Island")] NF = 164,
        [Display(Name = "Northern Mariana Islands")] MP = 165,
        [Display(Name = "Norway")] NO = 166,
        [Display(Name = "Oman")] OM = 167,
        [Display(Name = "Pakistan")] PK = 168,
        [Display(Name = "Palau")] PW = 169,
        [Display(Name = "Palestine, State of")] PS = 170,
        [Display(Name = "Panama")] PA = 171,
        [Display(Name = "Papua New Guinea")] PG = 172,
        [Display(Name = "Paraguay")] PY = 173,
        [Display(Name = "Peru")] PE = 174,
        [Display(Name = "Philippines")] PH = 175,
        [Display(Name = "Pitcairn")] PN = 176,
        [Display(Name = "Poland")] PL = 177,
        [Display(Name = "Portugal")] PT = 178,
        [Display(Name = "Puerto Rico")] PR = 179,
        [Display(Name = "Qatar")] QA = 180,
        [Display(Name = "Réunion")] RE = 181,
        [Display(Name = "Romania")] RO = 182,
        [Display(Name = "Russian Federation")] RU = 183,
        [Display(Name = "Rwanda")] RW = 184,
        [Display(Name = "Saint Barthélemy")] BL = 185,
        [Display(Name = "Saint Helena, Ascension and Tristan da Cunha")] SH = 186,
        [Display(Name = "Saint Kitts and Nevis")] KN = 187,
        [Display(Name = "Saint Lucia")] LC = 188,
        [Display(Name = "Saint Martin (French part)")] MF = 189,
        [Display(Name = "Saint Pierre and Miquelon")] PM = 190,
        [Display(Name = "Saint Vincent and the Grenadines")] VC = 191,
        [Display(Name = "Samoa")] WS = 192,
        [Display(Name = "San Marino")] SM = 193,
        [Display(Name = "Sao Tome and Principe")] ST = 194,
        [Display(Name = "Saudi Arabia")] SA = 195,
        [Display(Name = "Senegal")] SN = 196,
        [Display(Name = "Serbia")] RS = 197,
        [Display(Name = "Seychelles")] SC = 198,
        [Display(Name = "Sierra Leone")] SL = 199,
        [Display(Name = "Singapore")] SG = 200,
        [Display(Name = "Sint Maarten (Dutch part)")] SX = 201,
        [Display(Name = "Slovakia")] SK = 202,
        [Display(Name = "Slovenia")] SI = 203,
        [Display(Name = "Solomon Islands")] SB = 204,
        [Display(Name = "Somalia")] SO = 205,
        [Display(Name = "South Africa")] ZA = 206,
        [Display(Name = "South Georgia and the South Sandwich Islands")] GS = 207,
        [Display(Name = "South Sudan")] SS = 208,
        [Display(Name = "Spain")] ES = 209,
        [Display(Name = "Sri Lanka")] LK = 210,
        [Display(Name = "Sudan")] SD = 211,
        [Display(Name = "Suriname")] SR = 212,
        [Display(Name = "Svalbard and Jan Mayen")] SJ = 213,
        [Display(Name = "Swaziland")] SZ = 214,
        [Display(Name = "Sweden")] SE = 215,
        [Display(Name = "Switzerland")] CH = 216,
        [Display(Name = "Syrian Arab Republic")] SY = 217,
        [Display(Name = "Taiwan, Province of China[a]")] TW = 218,
        [Display(Name = "Tajikistan")] TJ = 219,
        [Display(Name = "Tanzania, United Republic of")] TZ = 220,
        [Display(Name = "Thailand")] TH = 221,
        [Display(Name = "Timor-Leste")] TL = 222,
        [Display(Name = "Togo")] TG = 223,
        [Display(Name = "Tokelau")] TK = 224,
        [Display(Name = "Tonga")] TO = 225,
        [Display(Name = "Trinidad and Tobago")] TT = 226,
        [Display(Name = "Tunisia")] TN = 227,
        [Display(Name = "Turkey")] TR = 228,
        [Display(Name = "Turkmenistan")] TM = 229,
        [Display(Name = "Turks and Caicos Islands")] TC = 230,
        [Display(Name = "Tuvalu")] TV = 231,
        [Display(Name = "Uganda")] UG = 232,
        [Display(Name = "Ukraine")] UA = 233,
        [Display(Name = "United Arab Emirates")] AE = 234,
        [Display(Name = "United Kingdom of Great Britain and Northern Ireland")] GB = 235,
        [Display(Name = "United States of America")] US = 236,
        [Display(Name = "United States Minor Outlying Islands")] UM = 237,
        [Display(Name = "Uruguay")] UY = 238,
        [Display(Name = "Uzbekistan")] UZ = 239,
        [Display(Name = "Vanuatu")] VU = 240,
        [Display(Name = "Venezuela (Bolivarian Republic of)")] VE = 241,
        [Display(Name = "Viet Nam")] VN = 242,
        [Display(Name = "Virgin Islands (British)")] VG = 243,
        [Display(Name = "Virgin Islands (U.S.)")] VI = 244,
        [Display(Name = "Wallis and Futuna")] WF = 245,
        [Display(Name = "Western Sahara")] EH = 246,
        [Display(Name = "Yemen")] YE = 247,
        [Display(Name = "Zambia")] ZM = 248,
        [Display(Name = "Zimbabwe")] ZW = 249,
    }

    public enum Province
    {
        [Display(Name = "Eastern Cape")] Eastern_Cape,
        [Display(Name = "Free State")] Free_State,
        [Display(Name = "Gauteng")] Gauteng,
        [Display(Name = "Kwa-Zulu Natal")] KwaZulu_Natal,
        Limpopo,
        Mpumalanga,
        [Display(Name = "Northern Cape")] Northern_Cape,
        [Display(Name = "North West")] North_West,
    }
}

