import pandas as pd
import os
import requests
import json

def load_model_results():
  xls = pd.ExcelFile('../data/ModelResults.xlsx')
  sheets = xls.sheet_names
  all_models = []
  for sheet in sheets:
    [model, commodity] = sheet.split('_', 2)
    df = pd.read_excel(xls, sheet, parse_dates=["Date"], index_col="Date")
    df['model'] = model
    df['commodity'] = commodity
    all_models.append(df)
  df = pd.concat(all_models)
  print(df)
  return df

def apply_calculations(df):
  # Pnl YTD
  df_grouped = df.groupby([pd.Grouper(freq='YS'), 'model', 'commodity'])
  df["pnlYtd"] = df_grouped['Pnl Daily'].cumsum()

  # Pnl LTD
  df_grouped = df.groupby(['model', 'commodity'])
  df["pnlLtd"] = df_grouped['Pnl Daily'].cumsum()

  # Drawdown YTD
  df_grouped = df.groupby([pd.Grouper(freq='YS'), 'model', 'commodity'])
  df["mddYtd"] = df_grouped['Pnl Daily'].transform(lambda x: (x.cummin() - x.cummax()) / x.cummax())

  return df

def ingest_models(df):
  api_address = os.environ['API']
  df = df.rename(columns={"Contract": "contract", "Price": "price", "Position":"position", "Date":"date", "New Trade Action": 'newTradeAction', 'Pnl Daily': 'pnlDaily'})
  idx = df.index.names = ['date']
  report = json.loads(df.to_json(orient='table', index=True))
  reportOutput = json.dumps({'rows': report['data']})
  headers = { 'Accept' : 'application/json', 'Content-Type' : 'application/json'}
  r = requests.post(f"{api_address}/Data/models", data=reportOutput, headers=headers, verify=False)
  return {'rows': report['data']}