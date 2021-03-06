import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class ProfilesService{

  async getProfile(profileId){
    AppState.profile = {}
    const res = await api.get(`api/profiles/${profileId}`)
    logger.log('getProfile', res.data)
    AppState.profile = res.data
  }

  async getVaults(profileId){
    AppState.vaults = []
    const res = await api.get(`api/profiles/${profileId}/vaults`)
    AppState.vaults = res.data
    logger.log('getVaults', AppState.vaults)
  }

  async getUserVaults(profileId){
    AppState.userVaults = []
    const res = await api.get(`api/profiles/${profileId}/vaults`)
    AppState.userVaults = res.data
    logger.log('getUserVaults', AppState.userVaults)
  }

  async getKeeps(profileId){
    AppState.profileKeeps = []
    const res = await api.get(`api/profiles/${profileId}/keeps`)
    logger.log(res)
    AppState.profileKeeps = res.data
    logger.log('getKeeps', AppState.profileKeeps)
  }

  async updateProfile(newData, profileId){
    const res = await api.put(`api/profiles/${profileId}`, newData)
    logger.log(res)
    AppState.profile = res.data
  }

}

export const profilesService = new ProfilesService()