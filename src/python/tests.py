from requestservice.requestservice import RequestService

if __name__ == '__main__':
	headers = {
		'Accept': 'application/json',
		'x-api-key': '$2a$10$nQbijfkxFBivKX1Qs27Qb.Embllxxu0cZY5Nbj7lgKz446AteykbG'
	}

	r_service = RequestService("https://api.curseforge.com", headers)

	params = {
		'gameId': '432',
		"gameVersion": '1.16.5',
		"modLoaderType ": 1,
		"classId": 6,
		"sortType": 2,
		"sortOrder": 'desc'
	}

	test = r_service.get("/v1/mods/search", params)
	print(test.json())