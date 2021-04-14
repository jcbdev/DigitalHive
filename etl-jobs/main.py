import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns
from price_stitching import load_timeseries, process
sns.set_style("darkgrid")

if __name__ == '__main__':
  df = load_timeseries()
  df = process(df)
  print(df)