import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class ProfilesService{

  async getProfile(profileId){
    AppState.profile = {}
    const res = await api.get(`api/profiles/${profileId}`)
    AppState.profile = res.data
  }

  async getVaults(profileId){
    AppState.vaults = []
    const res = await api.get(`api/profiles/${profileId}/vaults`)
    AppState.vaults = res.data
  }

  async getKeeps(profileId){
    AppState.profileKeeps = []
    const res = await api.get(`api/profiles/${profileId}/keeps`)
    logger.log(res)
    AppState.profileKeeps = res.data
    logger.log(AppState.profileKeeps)
  }

}

export const profilesService = new ProfilesService()