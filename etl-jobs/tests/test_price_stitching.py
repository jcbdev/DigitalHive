from price_stitching import load_timeseries, rolling_window, ingest_rolling_data
import datatest as dt
from pandas import util
from requests import HTTPError
import os

def test_load_timeseries():
  df = load_timeseries()
  required_columns = {'Contract1', 'Contract1Value', 'Contract2', 'Contract2Value'}
  dt.validate(df.columns, required_columns)

def test_apply_rolling_window():
  df = load_timeseries()
  df = rolling_window(df, window='15D')
  required_columns = {'Contract1', 'Contract1Value', 'Contract1ValueRolling'}
  dt.validate(df.columns, required_columns)

def test_should_call_api(requests_mock):
  df = util.testing.makeDataFrame()
  os.environ['API'] = 'https://localhost:5001'
  requests_mock.post(f'https://localhost:5001/Data/timeseries', status_code=200)
  json = ingest_rolling_data(df)
  assert json['rows'] is not None