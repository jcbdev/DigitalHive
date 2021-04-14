from price_stitching import load_timeseries, process
import datatest as dt

def test_load_timeseries():
  df = load_timeseries()
  required_columns = {'Contract1', 'Contract1Value', 'Contract2', 'Contract2Value'}
  dt.validate(df.columns, required_columns)

def test_should_shape_data():
  df = load_timeseries()
  df = process(df)
  print('hello')