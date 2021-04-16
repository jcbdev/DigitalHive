from model_results import load_model_results, apply_calculations, ingest_models
import datatest as dt
from pandas import util
from requests import HTTPError
import os

def test_load_model_results():
  df = load_model_results()
  required_columns = {'Contract', 'Price', 'Position', 'New Trade Action', 'Pnl Daily', 'model', 'commodity'}
  dt.validate(df.columns, required_columns)
  assert 'Model1' in df['model'].tolist()
  assert 'Model2' in df['model'].tolist()
  assert 'Commodity1' in df['commodity'].tolist()
  assert 'Commodity2' in df['commodity'].tolist()

def test_should_apply_calculations():
  df = load_model_results()
  df = apply_calculations(df)
  print (df)
  required_columns = {'Contract', 'Price', 'Position', 'New Trade Action', 'Pnl Daily', 'model', 'commodity', 'pnlYtd', 'pnlLtd', 'mddYtd'}
  dt.validate(df.columns, required_columns)

def test_should_call_api(requests_mock):
  df = util.testing.makeDataFrame()
  os.environ['API'] = 'https://localhost:5001'
  requests_mock.post(f'https://localhost:5001/Data/models', status_code=200)
  json = ingest_models(df)
  assert json['rows'] is not None