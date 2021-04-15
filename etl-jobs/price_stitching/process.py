import pandas as pd

def load_timeseries():
  xls = pd.ExcelFile('../data/InputRawData.xlsx')
  df = pd.read_excel(xls, 'Sheet1', parse_dates=["Date"], index_col="Date")
  return df

def rolling_window(df, window):
  df = df.loc[:, ('Contract1', 'Contract1Value')]
  df['Contract1ValueRolling'] = df['Contract1Value'].rolling(window='15D').mean()
  return df

def ingest_rolling_data(df):
  pass