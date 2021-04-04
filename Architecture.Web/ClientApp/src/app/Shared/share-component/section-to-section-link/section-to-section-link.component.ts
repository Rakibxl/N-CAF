import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { scaleAnimation } from '../../Modules/animations/animationRightToggle';
import { SectionLinkService } from '../../Services/Users/section-link.service';


@Component({
  selector: 'app-section-to-section-link',
  templateUrl: './section-to-section-link.component.html',
    styleUrls: ['./section-to-section-link.component.css'],
    animations: [scaleAnimation]
})
export class SectionToSectionLinkComponent implements OnInit {
    @Input() sectionName: string;
    @Input() profileId: number = 0;
    constructor(private sectionLinkService: SectionLinkService, private route: ActivatedRoute, private router: Router) { }

    animationOpen: string = 'out';
    public sectionLinkCollection: any[]=[];

    toggleClick() {
        this.animationOpen = this.animationOpen === 'out' ? 'in' : 'out';
    }
    closeChatbox = () => { this.animationOpen = 'out'; }


    ngOnInit() {
        console.log("sectionName: ", this.sectionName);
        if (this.profileId == 0) {
            this.profileId = (+this.route.snapshot.paramMap.get("profId") || 0);
        }
        this.sectionLinkService.getSectionBySectionName(this.sectionName).subscribe((data) => {
            console.log("data:", data);
            this.sectionLinkCollection = data.data || [];
        },
            (err) => {
                console.log("Error : ", err);
            });
    }

    public fnRedirectToActionPage(sectionLinkInfo: any) {
        let jumpUrl = "";
        console.log("sectionLinkInfo:", sectionLinkInfo);
        if ((sectionLinkInfo.actionLink || "") != "") {
            debugger;
            var urlCheck =/http|https|www/;
            if (urlCheck.test(sectionLinkInfo.actionLink)) {
                console.log(urlCheck.test(sectionLinkInfo.actionLink));
                jumpUrl = sectionLinkInfo.actionLink;
            } else {
                jumpUrl = window.location.hostname + sectionLinkInfo.actionLink;
                sectionLinkInfo.actionLink = sectionLinkInfo.actionLink.replace("{profileId}", this.profileId);
                const url = this.router.serializeUrl(
                    this.router.createUrlTree([sectionLinkInfo.actionLink])
                );
                window.open(url, '_blank');
            }


            var redirectWindow = window.open(jumpUrl, '_blank');
            redirectWindow.location;

        }

    }

}
