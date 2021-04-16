import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns
from model_results import apply_calculations, ingest_models, load_model_results
from dotenv import load_dotenv

if __name__ == '__main__':
  load_dotenv("../.env")
  df = load_model_results()
  df = apply_calculations(df)
  ingest_models(df)
  # print(df)