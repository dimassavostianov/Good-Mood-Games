using System.Collections.Generic;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Core.GoogleServices
{
    public static class GoogleSheetDataService
    {
        private const string ApplicationName = "GoodMoodGames";
        private const string CredentialsPath = "Assets/Resources/user-config.json";
        
        private static readonly string[] Scopes = {"https://www.googleapis.com/auth/spreadsheets"};
        private static UserCredential _credentials;

        private static bool CredentialsInitialized { get; set; }

        public static IList<IList<object>> RetrieveGoogleSheetData(string spreadsheetId,
            string sheetName = null)
        {
            if (!CredentialsInitialized) InitializeCredentials();

            var values = GetValues(spreadsheetId, sheetName);
            if (values == null || values.Count == 0)
                Debug.LogWarning($"No data found in spreadsheet {spreadsheetId} {sheetName}");

            return values;
        }

        public static IList<Sheet> RetrieveGoogleSheets(string spreadsheetId)
        {
            if (!CredentialsInitialized) InitializeCredentials();

            var values = GetSheets(spreadsheetId);
            if (values == null || values.Count == 0)
                Debug.LogWarning($"No sheets found in spreadsheet {spreadsheetId}");

            return values;
        }

        private static IList<IList<object>> GetValues(string spreadsheetId, string sheetName)
        {
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = _credentials,
                ApplicationName = ApplicationName,
            });

            var request = service.Spreadsheets.Values.Get(spreadsheetId, $"{sheetName}!A:ZZZ");
            var response = request.Execute();
            var values = response.Values;

            return values;
        }

        private static IList<Sheet> GetSheets(string spreadsheetId)
        {
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = _credentials,
                ApplicationName = ApplicationName,
            });

            var request = service.Spreadsheets.Get(spreadsheetId);
            var response = request.Execute();

            return response.Sheets;
        }
        
        private static void InitializeCredentials()
        {
            if (!File.Exists(CredentialsPath))
            {
                Debug.LogError($"Unable to find Google API credentials at {CredentialsPath}");
                return;
            }

            using (var stream = new FileStream(CredentialsPath, FileMode.Open, FileAccess.ReadWrite))
            {
                const string credPath = "token.json";

                _credentials = GoogleWebAuthorizationBroker
                    .AuthorizeAsync(GoogleClientSecrets.FromStream(stream).Secrets, Scopes, "user",
                        CancellationToken.None, new FileDataStore(credPath)).Result;

                CredentialsInitialized = true;
                Debug.Log("Credential file saved to: " + credPath);
            }
        }
    }
}