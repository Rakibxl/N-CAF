import { Component, OnInit, Input } from '@angular/core';
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
    constructor(private sectionLinkService: SectionLinkService) { }

    animationOpen: string = 'out';
    public sectionLinkCollection: any[]=[];

    toggleClick() {
        this.animationOpen = this.animationOpen === 'out' ? 'in' : 'out';
    }
    closeChatbox = () => { this.animationOpen = 'out'; }


    ngOnInit() {
        console.log("sectionName: ", this.sectionName);
        this.sectionLinkService.getSectionBySectionName(this.sectionName).subscribe((data) => {
            console.log("data:", data);
            this.sectionLinkCollection = data.data || [];
        },
            (err) => {
                console.log("Error : ", err);
            });
    }

}
