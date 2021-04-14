import pandas as pd

def load_timeseries():
  xls = pd.ExcelFile('../data/InputRawData.xlsx')
  df = pd.read_excel(xls, 'Sheet1', parse_dates=["Date"], index_col="Date")
  return df