def process(df):
  # df = df[["Contract1Value", "Contract2Value"]]
  df = df.loc[:, ('Contract1Value', 'Contract2Value')]
  # Spec says based on previous day -> "on the day before the contract change calculate the roll as Contract1-Contract2"
  # will set 
  # df['Roll'] = df.loc[-1, 'Contract1Value'] - df.loc[-1, 'Contract2Value']
  df['Roll'] = df.Contract1Value.shift(1) - df.Contract2Value.shift(1)
  # df['Roll'] = 0
  # for i in df.Date:
  #   df.loc[i, 'Roll'] = df.loc[i-1, "Contract1Value"] - df.loc[i-1, "Contract1Value"]
  # df['Roll'] = df['Roll'].fillna(0)

  # Now perform a backward cumulative sum on the Roll values -> "Then cumulative sum of the roll value in reverse order (Latest date to historic) will be the final roll value series."
  # df['Roll'] = df['Roll'].values[::-1]
  # df['RollValueSeries'] = df['Roll'].rolling(3).mean()
  df['Contract1ValueRolling'] = df['Contract1Value'].rolling(window='15D').mean()
  df.to_csv('test.csv')
  return df