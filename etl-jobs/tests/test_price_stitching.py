from price_stitching import load_timeseries, rolling_window
import datatest as dt

def test_load_timeseries():
  df = load_timeseries()
  required_columns = {'Contract1', 'Contract1Value', 'Contract2', 'Contract2Value'}
  dt.validate(df.columns, required_columns)

def test_apply_rolling_window():
  df = load_timeseries()
  df = rolling_window(df, window='15D')
  required_columns = {'Contract1', 'Contract1Value', 'Contract1ValueRolling'}
  dt.validate(df.columns, required_columns)