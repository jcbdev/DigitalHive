import pandas as pd
import os
import requests
import json

def load_timeseries():
  xls = pd.ExcelFile('../data/InputRawData.xlsx')
  df = pd.read_excel(xls, 'Sheet1', parse_dates=["Date"], index_col="Date")
  return df

def rolling_window(df, window):
  df = df.loc[:, ('Contract1', 'Contract1Value')]
  df['Contract1ValueRolling'] = df['Contract1Value'].rolling(window='15D').mean()
  return df

def ingest_rolling_data(df):
  api_address = os.environ['API']
  df = df.rename(columns={"Contract1": "contract", "Contract1Value": "value", "Contract1ValueRolling":"rollingValue", "Date":"date"})
  idx = df.index.names = ['date']
  report = json.loads(df.to_json(orient='table', index=True))
  reportOutput = json.dumps({'rows': report['data']})
  headers = { 'Accept' : 'application/json', 'Content-Type' : 'application/json'}
  # print(reportOutput)
  r = requests.post(f"{api_address}/Data/timeseries", data=reportOutput, headers=headers, verify=False)
  return {'rows': report['data']}