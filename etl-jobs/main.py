import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns
from price_stitching import load_timeseries, rolling_window, ingest_rolling_data
from dotenv import load_dotenv

if __name__ == '__main__':
  load_dotenv("../.env")
  df = load_timeseries()
  df = rolling_window(df, '15D')
  
  print(df)