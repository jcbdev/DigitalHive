import requests
import os
from dotenv import load_dotenv

if __name__ == '__main__':
  load_dotenv("../.env")
  api_address = os.environ['API']
  headers = { 'Accept' : 'application/json', 'Content-Type' : 'application/json'}
  r = requests.post(f"{api_address}/Data/clear", data={}, headers=headers, verify=False)