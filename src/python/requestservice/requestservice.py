import requests

class RequestService():
	def __init__(self, host: str, headers: dict):
		self.headers = headers
		self.host = host

	def get(self, path: str, params: dict=None):
		print(params)
		return requests.get(f'{self.host}{path}', params=params, headers=self.headers)

