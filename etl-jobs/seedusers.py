import requests
import os
from dotenv import load_dotenv
import json

if __name__ == '__main__':
  load_dotenv("../.env")
  api_address = os.environ['API']
  headers = { 'Accept' : 'application/json', 'Content-Type' : 'application/json'}
  r = requests.post(f"{api_address}/Users/register", data=json.dumps({ 'username': 'james1', 'role': 'Manager', 'password': 'password1' }), headers=headers, verify=False)
  r = requests.post(f"{api_address}/Users/register", data=json.dumps({ 'username': 'james2', 'role': 'Trader', 'password': 'password1' }), headers=headers, verify=False)
  r = requests.post(f"{api_address}/Users/register", data=json.dumps({ 'username': 'james3', 'role': 'Developer', 'password': 'password1' }), headers=headers, verify=False)