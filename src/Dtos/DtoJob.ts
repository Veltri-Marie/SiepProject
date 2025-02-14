export interface DtoJob {
    id: number;
    isActive: boolean;
    isIntro: boolean;
    isRegulated: boolean;
    isPriority: boolean;
    status: string;
    name: string;
    excerpt: string;
    tags: string[];
    description: string;
    knowHows: string[];
    softSkills: string[];
    requiredTitle: string;
    requiredTitleLastUpdated: Date | null;
    professionalFramework: string;
    synonyms: string[];
    parentJobId?: number | null;
    languageLink: string;
    updateDate: Date;
    relatedJobsIds: number[];
    relatedSectorsIds: number[];
    relatedInterviewsIds: number[];
    relatedFederationsIds: number[];
    relatedNewsIds: number[];
    relatedPublicationsIds: number[];
    authorsIds: number[];
    isShortageJob: boolean;
}
