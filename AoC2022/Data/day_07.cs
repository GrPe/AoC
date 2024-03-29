﻿namespace AoC2022.Data;

internal class day_07
{
    public const string test_data = @"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k";

    public const string data = @"$ cd /
$ ls
dir fwbjchs
dir hmnpr
dir jtrbrcjl
dir lcgv
dir ldqc
dir vrvl
$ cd fwbjchs
$ ls
154619 wqdlv.mdw
21648 wvbnz
$ cd ..
$ cd hmnpr
$ ls
178623 rftqqsrp.bfm
$ cd ..
$ cd jtrbrcjl
$ ls
dir nmbfwc
dir whqb
$ cd nmbfwc
$ ls
242645 lcgv
256365 wdzw.drg
$ cd ..
$ cd whqb
$ ls
161522 mrqgpv.gsm
48062 vpsgcl.gfh
$ cd ..
$ cd ..
$ cd lcgv
$ ls
dir cthtlwds
dir grldv
dir lnztfr
dir vwhf
dir znmzg
$ cd cthtlwds
$ ls
dir dghvw
dir tfwgg
$ cd dghvw
$ ls
107090 jmj.lzh
$ cd ..
$ cd tfwgg
$ ls
dir ddnfmsjc
252616 fvj
dir gng
dir lcgv
234528 mpb
181198 pzqgf.cjd
dir svvz
$ cd ddnfmsjc
$ ls
dir hwmcsdvt
dir lcgv
$ cd hwmcsdvt
$ ls
208912 wdzw.drg
$ cd ..
$ cd lcgv
$ ls
47252 tnd.ztd
$ cd ..
$ cd ..
$ cd gng
$ ls
44313 pzqgf.cjd
$ cd ..
$ cd lcgv
$ ls
182616 wdzw.drg
$ cd ..
$ cd svvz
$ ls
86968 sqtggfv
33927 vfmltgs
$ cd ..
$ cd ..
$ cd ..
$ cd grldv
$ ls
145761 mrqgpv.gsm
dir wqdlv
$ cd wqdlv
$ ls
96902 jhmsp
157064 mrqgpv.gsm
$ cd ..
$ cd ..
$ cd lnztfr
$ ls
137978 bpq
180941 fvpfmwn
148685 hsg.qgj
865 mrqgpv.gsm
$ cd ..
$ cd vwhf
$ ls
dir bgtgqzz
dir fcwzw
dir lcgv
dir mrlvtb
116134 mrqgpv.gsm
dir wszvqd
$ cd bgtgqzz
$ ls
dir dzpjg
283411 nmbfwc
dir smhhzq
240602 ttlbcssq
$ cd dzpjg
$ ls
75545 cmfw.gsj
189219 lcgv.chq
255580 lqndrsh.szf
175733 mrqgpv.gsm
$ cd ..
$ cd smhhzq
$ ls
137259 thjwcz.qhn
$ cd ..
$ cd ..
$ cd fcwzw
$ ls
59717 tpljg
$ cd ..
$ cd lcgv
$ ls
148881 mrzcdzd.gjt
68671 pzqgf.cjd
242866 slpftp
89945 vpsgcl.gfh
196497 wdzw.drg
$ cd ..
$ cd mrlvtb
$ ls
40003 rfzrwc.zjn
$ cd ..
$ cd wszvqd
$ ls
dir bhhtbv
dir lcpvwdq
$ cd bhhtbv
$ ls
dir fbh
248604 ldscpjmp
dir nmbfwc
$ cd fbh
$ ls
256295 vpsgcl.gfh
$ cd ..
$ cd nmbfwc
$ ls
83799 lcgv.vfc
$ cd ..
$ cd ..
$ cd lcpvwdq
$ ls
dir lwhq
212569 rfzrwc.clp
23957 wdzw.drg
$ cd lwhq
$ ls
240867 fzrwpl.hqd
68771 mzsqgswh
88777 pqtqv.qwz
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd znmzg
$ ls
30277 gltpwzg.gjd
211983 wdzw.drg
$ cd ..
$ cd ..
$ cd ldqc
$ ls
dir dnzfqzwv
dir dvshtm
97119 gdnlwmbf
dir gqb
dir jclb
dir jgbsw
115989 lcgv.hlf
255836 lchqqdh.wrn
dir qtdlb
dir rmljszcj
dir tqwpmw
dir vhdgcsw
$ cd dnzfqzwv
$ ls
dir tqv
$ cd tqv
$ ls
139984 dwhz.nhz
240411 pzqgf.cjd
129386 rnnr
190691 svgwt.mql
$ cd ..
$ cd ..
$ cd dvshtm
$ ls
dir lcgv
96767 mrqgpv.gsm
dir qdmmpq
$ cd lcgv
$ ls
82949 bldf.hwn
$ cd ..
$ cd qdmmpq
$ ls
dir lzgwflt
dir vgrdpbg
$ cd lzgwflt
$ ls
148651 tndbwbh
$ cd ..
$ cd vgrdpbg
$ ls
dir wqdlv
$ cd wqdlv
$ ls
130393 rqjc.dnr
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd gqb
$ ls
dir jtf
dir lvwpqs
212592 mrzcdzd.gjt
70051 tqpwdwm.nzz
dir vznbng
52226 wbsdrsfh.tfw
$ cd jtf
$ ls
232635 lvpccb.dmm
105086 wdzw.drg
$ cd ..
$ cd lvwpqs
$ ls
124821 dmhqlt
265915 mrqgpv.gsm
45481 pzqgf.cjd
$ cd ..
$ cd vznbng
$ ls
42179 nrzcpgvl.jft
17752 tld.ghn
174859 zvqglbw.ppl
$ cd ..
$ cd ..
$ cd jclb
$ ls
dir bnz
dir dtmtvbw
dir hnlrtpbz
dir pbb
dir vhjwtq
dir vpfggv
dir zmflq
$ cd bnz
$ ls
199447 mrzcdzd.gjt
$ cd ..
$ cd dtmtvbw
$ ls
dir bjthn
dir hzlhz
dir zmflq
$ cd bjthn
$ ls
272777 pgqfn.tdd
$ cd ..
$ cd hzlhz
$ ls
50958 lcgv.gvq
$ cd ..
$ cd zmflq
$ ls
207442 rrnwns.zpf
15759 wdzw.drg
$ cd ..
$ cd ..
$ cd hnlrtpbz
$ ls
69788 jhqjs.sdj
219666 jljzp.mhf
137518 jqnfg
108183 shfjz.vnr
130164 vpsgcl.gfh
$ cd ..
$ cd pbb
$ ls
dir wqdlv
dir zmflq
$ cd wqdlv
$ ls
dir fgggwt
dir hrghbhj
dir nmbfwc
dir tgmqnq
146479 vpsgcl.gfh
dir wqdlv
$ cd fgggwt
$ ls
264892 wqdlv.zsp
$ cd ..
$ cd hrghbhj
$ ls
116698 bfwtbg
dir lcgv
92758 pzqgf.cjd
dir tsdjgt
284427 vpsgcl.gfh
229621 wqdlv.pml
dir zfjjncvd
$ cd lcgv
$ ls
30459 mrzcdzd.gjt
dir wqdlv
$ cd wqdlv
$ ls
78475 wdzw.drg
$ cd ..
$ cd ..
$ cd tsdjgt
$ ls
166330 jpfms
16410 tjswm.bqv
$ cd ..
$ cd zfjjncvd
$ ls
59841 mrqgpv.gsm
$ cd ..
$ cd ..
$ cd nmbfwc
$ ls
dir jtn
151403 mmjm
240129 mmsb
206021 nmbfwc.sds
84439 vpsgcl.gfh
dir wqdlv
dir zvnrwfhn
$ cd jtn
$ ls
23555 hmmt.gbb
$ cd ..
$ cd wqdlv
$ ls
69742 jppj.vvg
$ cd ..
$ cd zvnrwfhn
$ ls
242009 lcgv.bds
$ cd ..
$ cd ..
$ cd tgmqnq
$ ls
259985 bzqjt
46410 flsm.szr
dir lcgv
89561 npfmc.vqs
17503 vpsgcl.gfh
73719 wqdlv.gjn
$ cd lcgv
$ ls
dir dzfglmz
177553 ffvzsgz
dir ljt
216443 mrzcdzd.gjt
255381 nmbfwc
dir rplqnt
84061 zmflq.vlw
$ cd dzfglmz
$ ls
220883 dqbcfgfd
$ cd ..
$ cd ljt
$ ls
11842 rfzrwc.hpn
$ cd ..
$ cd rplqnt
$ ls
119893 lszmvzst.zng
$ cd ..
$ cd ..
$ cd ..
$ cd wqdlv
$ ls
dir chnpddzn
272999 hbhwqt.fsl
144546 jvhjnsz
dir ppsm
102615 pzqgf.cjd
dir swdnss
$ cd chnpddzn
$ ls
256977 pzqgf.cjd
dir wqdlv
$ cd wqdlv
$ ls
6565 hlcqgmj
$ cd ..
$ cd ..
$ cd ppsm
$ ls
238358 fvw.bzw
dir ggjnl
265010 mrzcdzd.gjt
201818 rfzrwc
dir ssggblm
$ cd ggjnl
$ ls
45841 nlnrrqf.fwn
$ cd ..
$ cd ssggblm
$ ls
276584 djqb.ngq
18926 lcgv
$ cd ..
$ cd ..
$ cd swdnss
$ ls
dir bmrzhjs
$ cd bmrzhjs
$ ls
269825 mrqgpv.gsm
3162 rdmbdwq.bmv
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd zmflq
$ ls
dir hnrnldw
dir lcgv
dir mpmcghz
dir nbbv
dir qsnfzp
dir tntnjg
dir wqdlv
$ cd hnrnldw
$ ls
102631 wjbbjwtm.vvz
$ cd ..
$ cd lcgv
$ ls
dir dzz
dir hbzzf
dir jncrbhc
205204 lqnrp
dir mzzpfnr
dir nmbfwc
dir rfzrwc
dir rnrmhfz
dir zmflq
$ cd dzz
$ ls
dir cvvdv
226221 nggtqdzn
94641 npmpjnjm.bzg
dir rsdw
dir sjrb
41983 vfdz.ngz
271561 zmflq.zsc
$ cd cvvdv
$ ls
64260 hhqv.tsg
31245 pzqgf.cjd
280268 znjjp
$ cd ..
$ cd rsdw
$ ls
dir lcgv
$ cd lcgv
$ ls
37080 nmbfwc
$ cd ..
$ cd ..
$ cd sjrb
$ ls
233530 mrqgpv.gsm
$ cd ..
$ cd ..
$ cd hbzzf
$ ls
36018 mrqgpv.gsm
$ cd ..
$ cd jncrbhc
$ ls
205345 mrqgpv.gsm
244683 nqpcpt
$ cd ..
$ cd mzzpfnr
$ ls
dir hmjzlr
dir lcgv
dir mczs
dir wqdlv
90391 wqdlv.pdr
144119 zmflq
$ cd hmjzlr
$ ls
268342 svsd.jcd
$ cd ..
$ cd lcgv
$ ls
dir pwhl
dir rfzrwc
$ cd pwhl
$ ls
42795 gvmt
82576 wdzw.drg
$ cd ..
$ cd rfzrwc
$ ls
dir jjl
dir mqp
156985 mrqgpv.gsm
dir wptr
dir wqdlv
$ cd jjl
$ ls
dir jrjjr
104785 nmbfwc
20108 wdzw.drg
$ cd jrjjr
$ ls
243753 hgndlcrv.wbc
$ cd ..
$ cd ..
$ cd mqp
$ ls
142621 cljnbs
$ cd ..
$ cd wptr
$ ls
46279 vjqlvhrh.njr
$ cd ..
$ cd wqdlv
$ ls
104474 vpsgcl.gfh
$ cd ..
$ cd ..
$ cd ..
$ cd mczs
$ ls
186843 mrqgpv.gsm
dir pjm
dir thbwb
$ cd pjm
$ ls
dir wqdlv
$ cd wqdlv
$ ls
201647 sgtt
$ cd ..
$ cd ..
$ cd thbwb
$ ls
146494 mrqgpv.gsm
$ cd ..
$ cd ..
$ cd wqdlv
$ ls
103876 mrqgpv.gsm
$ cd ..
$ cd ..
$ cd nmbfwc
$ ls
dir fgctdds
dir rwgscjbv
$ cd fgctdds
$ ls
205015 bwvshdcz.dpp
$ cd ..
$ cd rwgscjbv
$ ls
242899 rbmtfdhp
$ cd ..
$ cd ..
$ cd rfzrwc
$ ls
dir bnsgzwhn
228624 ffj
dir lcgv
dir rcvwcbfd
268775 vbhsh.nnz
129373 vpsgcl.gfh
68919 wqdlv
dir wqmdw
dir zmflq
153277 zmflq.frv
$ cd bnsgzwhn
$ ls
9892 ltcrrzhb.njc
dir wpwmflr
dir zmflq
$ cd wpwmflr
$ ls
274142 bfj.fbw
dir rfzrwc
dir srnm
$ cd rfzrwc
$ ls
161517 mrqgpv.gsm
dir zbhgwsd
$ cd zbhgwsd
$ ls
43750 vbqmpbcr.zwz
$ cd ..
$ cd ..
$ cd srnm
$ ls
dir rvvtgr
$ cd rvvtgr
$ ls
164604 wzgbzbn
$ cd ..
$ cd ..
$ cd ..
$ cd zmflq
$ ls
184482 mrqgpv.gsm
80280 pzqgf.cjd
183303 zln.tbm
$ cd ..
$ cd ..
$ cd lcgv
$ ls
dir lcgv
dir pqttlp
$ cd lcgv
$ ls
dir bpjzg
$ cd bpjzg
$ ls
99853 wdzw.drg
$ cd ..
$ cd ..
$ cd pqttlp
$ ls
dir bgvhcgfn
45115 mrzcdzd.gjt
248058 qnvhgpw.ddw
112129 rfzrwc
$ cd bgvhcgfn
$ ls
228291 nmbfwc.gqj
$ cd ..
$ cd ..
$ cd ..
$ cd rcvwcbfd
$ ls
dir vtrtt
dir wgp
$ cd vtrtt
$ ls
138009 pzqgf.cjd
dir ztsvzpn
$ cd ztsvzpn
$ ls
51632 vpsgcl.gfh
$ cd ..
$ cd ..
$ cd wgp
$ ls
81030 lcgv.zhv
$ cd ..
$ cd ..
$ cd wqmdw
$ ls
dir zmrdf
$ cd zmrdf
$ ls
dir qqgw
$ cd qqgw
$ ls
58554 gqpqvplc.zvr
$ cd ..
$ cd ..
$ cd ..
$ cd zmflq
$ ls
224544 mrzcdzd.gjt
254976 pzqgf.cjd
$ cd ..
$ cd ..
$ cd rnrmhfz
$ ls
19759 lcgv.stz
$ cd ..
$ cd zmflq
$ ls
22390 nftzlqg.qmp
80148 wqdlv
$ cd ..
$ cd ..
$ cd mpmcghz
$ ls
169324 mrqgpv.gsm
65924 wdzw.drg
$ cd ..
$ cd nbbv
$ ls
115297 bqcrc.prw
58148 pvzv.qwf
dir wqdlv
$ cd wqdlv
$ ls
145268 mrzcdzd.gjt
35745 nmbfwc.hgv
112142 wqdlv
$ cd ..
$ cd ..
$ cd qsnfzp
$ ls
241308 nmbfwc.hmg
$ cd ..
$ cd tntnjg
$ ls
19543 mrqgpv.gsm
667 wqdlv
$ cd ..
$ cd wqdlv
$ ls
dir dqpgtmdl
dir jrqsqrv
189727 mrzcdzd.gjt
dir rfzrwc
208280 vpsgcl.gfh
281557 vwsljgn.mwd
119829 zmflq.hgd
$ cd dqpgtmdl
$ ls
268413 qcw.slb
$ cd ..
$ cd jrqsqrv
$ ls
238387 mvllmjc.wvm
213020 nqp.gdr
157257 nzdmplg.zqh
dir ppwcgc
24914 pzqgf.cjd
dir zjr
dir zmflq
$ cd ppwcgc
$ ls
249714 bsrnnhrr.spq
dir cvnd
$ cd cvnd
$ ls
248610 pzqgf.cjd
$ cd ..
$ cd ..
$ cd zjr
$ ls
224145 smwb.mmz
$ cd ..
$ cd zmflq
$ ls
250519 ftggp
147304 vpsgcl.gfh
238706 wdzw.drg
258323 wqdlv.bjp
dir wqgngf
$ cd wqgngf
$ ls
14302 bdz.jdw
dir jpgfsgd
dir ldwgr
22718 nwfh.nzf
$ cd jpgfsgd
$ ls
dir lcgv
dir qbrwz
$ cd lcgv
$ ls
284229 qhwc.zpq
dir wsjs
$ cd wsjs
$ ls
111635 lcgv
$ cd ..
$ cd ..
$ cd qbrwz
$ ls
199057 gpssftw.wdb
$ cd ..
$ cd ..
$ cd ldwgr
$ ls
260404 gdnpg.vjb
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd rfzrwc
$ ls
dir lmcg
$ cd lmcg
$ ls
32819 sjjztgr.rfj
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd vhjwtq
$ ls
dir qgqbrv
$ cd qgqbrv
$ ls
176900 gwbnqtn.rnj
$ cd ..
$ cd ..
$ cd vpfggv
$ ls
144809 cmc.srv
117565 nhddq.bqn
dir scw
dir tpmnhdc
dir vvp
71774 wqdlv.gdm
61647 zmflq
174026 zmflq.wzn
$ cd scw
$ ls
2295 bqbsrj.gnc
243386 mfmdqhh.mzl
$ cd ..
$ cd tpmnhdc
$ ls
dir fjwr
dir lcllz
dir nmbfwc
$ cd fjwr
$ ls
133256 pwgtqz.dpm
159987 vpsgcl.gfh
$ cd ..
$ cd lcllz
$ ls
dir flwws
210654 qmbfw.bsv
dir zmflq
$ cd flwws
$ ls
222222 nmbfwc.vhj
$ cd ..
$ cd zmflq
$ ls
235011 jlzfbt.wlb
49525 rfzrwc.fnc
$ cd ..
$ cd ..
$ cd nmbfwc
$ ls
133730 dqdqhvm
dir lcgv
188291 nmbfwc.qhv
110039 wdzw.drg
249996 wqdlv
dir zmflq
dir zppcvq
$ cd lcgv
$ ls
dir wths
$ cd wths
$ ls
120313 jdbtlf.rrn
$ cd ..
$ cd ..
$ cd zmflq
$ ls
124906 dqdcpzh
$ cd ..
$ cd zppcvq
$ ls
112537 mrzcdzd.gjt
$ cd ..
$ cd ..
$ cd ..
$ cd vvp
$ ls
dir fsw
194927 hvlm.pbd
dir nmbfwc
230376 pgsq
$ cd fsw
$ ls
111889 nmbfwc.smt
dir rfzrwc
$ cd rfzrwc
$ ls
282718 gbvss
$ cd ..
$ cd ..
$ cd nmbfwc
$ ls
dir fvh
160971 ngqvztv.hfg
dir rfzrwc
$ cd fvh
$ ls
256956 mrqgpv.gsm
14363 vbvsncs.jjw
172959 wdzw.drg
$ cd ..
$ cd rfzrwc
$ ls
257264 vpsgcl.gfh
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd zmflq
$ ls
10486 lbdtpnps.jhq
118145 rlgjvn.nvf
176390 wdzw.drg
$ cd ..
$ cd ..
$ cd jgbsw
$ ls
dir cfdljgh
214846 dwqdqv.ftq
dir rfzrwc
147094 vpsgcl.gfh
$ cd cfdljgh
$ ls
261471 mrqgpv.gsm
$ cd ..
$ cd rfzrwc
$ ls
dir fcvfw
dir gvqrwgrs
57417 zfqrqv.fvp
$ cd fcvfw
$ ls
279614 wdzw.drg
$ cd ..
$ cd gvqrwgrs
$ ls
dir sgfltf
$ cd sgfltf
$ ls
204207 mstlc.wtj
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd qtdlb
$ ls
dir gjpmcvwp
dir nsjlcmfz
dir wqdlv
$ cd gjpmcvwp
$ ls
dir cjjdzcwm
$ cd cjjdzcwm
$ ls
233873 pdnsrz.vfp
$ cd ..
$ cd ..
$ cd nsjlcmfz
$ ls
53472 nmbfwc
dir qvpj
$ cd qvpj
$ ls
150929 mrzcdzd.gjt
$ cd ..
$ cd ..
$ cd wqdlv
$ ls
dir qccsnjd
$ cd qccsnjd
$ ls
65908 hsrqhn.hjr
267802 zmflq.jdt
$ cd ..
$ cd ..
$ cd ..
$ cd rmljszcj
$ ls
dir jnstrbj
172566 nbtszsgl
dir wqdlv
$ cd jnstrbj
$ ls
232158 fgccmchh.wqg
236339 mrqgpv.gsm
281875 rfzrwc.sfd
$ cd ..
$ cd wqdlv
$ ls
58492 wdzw.drg
213853 wqdlv.zlz
$ cd ..
$ cd ..
$ cd tqwpmw
$ ls
92747 pzqgf.cjd
$ cd ..
$ cd vhdgcsw
$ ls
125104 crfw.sfv
dir flhbhzlt
139949 mrqgpv.gsm
dir rfzrwc
dir rnz
97174 zmflq.vpn
$ cd flhbhzlt
$ ls
282258 mrzcdzd.gjt
$ cd ..
$ cd rfzrwc
$ ls
dir lcgv
$ cd lcgv
$ ls
dir dlpng
dir glqrj
178245 lcgv
106863 nmbfwc.fgr
$ cd dlpng
$ ls
195950 rfzrwc
$ cd ..
$ cd glqrj
$ ls
248909 pzqgf.cjd
34214 vpsgcl.gfh
$ cd ..
$ cd ..
$ cd ..
$ cd rnz
$ ls
dir chfccv
dir cmsccq
dir zmflq
$ cd chfccv
$ ls
13688 mrqgpv.gsm
162142 vpsgcl.gfh
$ cd ..
$ cd cmsccq
$ ls
94122 dzpsltth
190025 rfzrwc
dir twqt
12230 wgghbcz.tph
60111 wqdlv
$ cd twqt
$ ls
109250 wdzw.drg
$ cd ..
$ cd ..
$ cd zmflq
$ ls
174075 wdzw.drg
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd vrvl
$ ls
dir pnfv
210089 rfzrwc
dir stcfmz
$ cd pnfv
$ ls
183315 rhmztnnh
$ cd ..
$ cd stcfmz
$ ls
115637 lcgv";
}
